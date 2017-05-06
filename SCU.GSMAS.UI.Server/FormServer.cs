using System;
using System.Net.Sockets;
using System.Net;
using System.Threading;
using System.IO;
using SCU.GSMAS.BLL;
using SCU.GSMAS.Model;
using SCU.GSMAS.Common;

namespace SCU.GSMAS.UI.Server
{
    public partial class FormServer : DevComponents.DotNetBar.OfficeForm
    {
        private TcpListener _listener;
        private Thread _th;
        private TblImageBll bllImg = new TblImageBll();
        public FormServer()
        {
            InitializeComponent();
        }

        private void FormServer_Load(object sender, EventArgs e)
        {
            startListening();
        }

        /// <summary>
        /// ����Ƿ��Ѿ���ĳ��ͼ�������ͼ
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        private bool checkCache(TblImage model)
        {
            string fileName = model.im_path + '/' + model.im_fileName;
            string thumbName = CommonHelper.getThumbPath(fileName);
            return File.Exists(thumbName);
        }

        private void startListening()
        {

            _listener = new TcpListener(IPAddress.Any, int.Parse("50000"));
            _listener.Start();
            ShowMsg("��������ʼ����");

            _th = new Thread(sendMsg);
            _th.Start();
            _th.IsBackground = true;
        }

        public void sendMsg()
        {
            while (true)
            {
                try
                {
                    using (TcpClient client = _listener.AcceptTcpClient())
                    {
                        if (!client.Connected)
                        {
                            return;
                        }
                        using (NetworkStream ns = client.GetStream())
                        {
                            if (ns != null)
                            {
                                byte[] header = new byte[CommonHelper.headerSize];
                                ns.Read(header, 0, CommonHelper.headerSize); //�ȶ����ļ�ͷ
                                switch (header[0])
                                {
                                    case (byte)Protocal.MSG_TEXT:
                                        break;
                                    case (byte)Protocal.MSG_IMAGE_ORIGIN:
                                        {
                                            int imgID = BitConverter.ToInt32(header, 1);
                                            TblImage model = bllImg.GetModel(imgID);
                                            string fileName = model.im_path + '/' + model.im_fileName;

                                            //if (!checkCache(model))
                                            //{
                                            //    getThumbNail(fileName, 1, 50, 50);
                                            //}

                                            ShowMsg("�ͻ���:" + client.Client.RemoteEndPoint.ToString());
                                            ShowMsg("�����ļ�:" + fileName);
                                            if (!File.Exists(fileName)) //����ļ������ڣ����ظ��ͻ�����Ϣ���ļ�������
                                            {
                                                ShowMsg("�ļ�������!");
                                                byte[] buffer = new byte[CommonHelper.headerSize];
                                                buffer[0] = (byte)Protocal.MSG_IMAGE_NOTEXIST;
                                                ns.Write(buffer, 0, CommonHelper.headerSize);
                                                return;
                                            }

                                            using (FileStream fs = new FileStream(@fileName.ToString(), FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                                            {
                                                byte[] sendHeader = new byte[CommonHelper.headerSize];
                                                sendHeader[0] = (byte)Protocal.MSG_IMAGE_ORIGIN;
                                                byte[] bufFileLen = new byte[4];
                                                bufFileLen = BitConverter.GetBytes(fs.Length);
                                                bufFileLen.CopyTo(sendHeader, 1);
                                                ns.Write(sendHeader, 0, CommonHelper.headerSize);//ͷ�ļ�д������
                                                int size = 0;//��ʼ����ȡ������Ϊ0   
                                                long len = 0;//��ʼ���Ѿ���ȡ������ 
                                                while (len < fs.Length)
                                                {
                                                    byte[] buffer = new byte[CommonHelper.recBufSize];
                                                    size = fs.Read(buffer, 0, buffer.Length);
                                                    ns.Write(buffer, 0, size);
                                                    len += size;
                                                }

                                            }
                                            ShowMsg("�ļ����ͳɹ�");
                                            break;
                                        }
                                    case (byte)Protocal.MSG_IMAGE_THUMBNAIL://��������ͼ
                                        {

                                            break;
                                        }

                                    default: break;
                                }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    ShowMsg("�����쳣��" + ex.Message);
                }
            }
        }

        private void ShowMsg(string msg)
        {
            if (listBox1.InvokeRequired)
            {
                listBox1.Invoke(new Action<string>((s) =>
                {
                    listBox1.Items.Add(s);
                }), msg);
            }
            else
            {
                listBox1.Items.Add(msg);
            }
        }


        private void getThumbNail(string imgPath, int mode, int width, int height)
        {
            int newH, newW;
            if (mode == 0) //�ٷֱ�ģʽ
            {
                newH = height;
                newW = width;
            }
            else //ָ������ģʽ
            {
                newH = height;
                newW = width;
            }

            string thumbPath = CommonHelper.getThumbPath(imgPath);

            ImageHelper.MakeThumbnail(imgPath, thumbPath, newW, newH, "HW");

        }


    }
}