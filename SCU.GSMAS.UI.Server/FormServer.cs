using System;
using System.Net.Sockets;
using System.Net;
using System.Threading;
using System.IO;
using SCU.GSMAS.BLL;
using SCU.GSMAS.Model;

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
                                byte[] file = new byte[400];
                                ns.Read(file, 0, 4); //�ȶ���imgID
                                int imgID = BitConverter.ToInt32(file, 0);
                                TblImage model = bllImg.GetModel(imgID);

                                string fileName = model.im_path + '/' + model.im_fileName;
                                ShowMsg("�ͻ������ӳɹ�" + client.Client.RemoteEndPoint.ToString());
                                ShowMsg("�����ļ�:" + fileName);

                                if (!File.Exists(fileName)) //����ļ������ڣ����ظ��ͻ�����Ϣ���ļ�������
                                {
                                    ShowMsg("�ļ�������!");
                                    byte[] buffer = new byte[512];
                                    buffer[0] = (byte)Common.GetFileResult.FileNotExist;
                                    //ns.Write()
                                    return;
                                }

                                using (FileStream fs = new FileStream(@fileName.ToString(), FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                                {
                                    byte[] filelen = new byte[4];
                                    filelen = BitConverter.GetBytes(fs.Length);
                                    ns.Write(filelen, 0, 4);
                                    int size = 0;//��ʼ����ȡ������Ϊ0   
                                    long len = 0;//��ʼ���Ѿ���ȡ������ 
                                    while (len < fs.Length)
                                    {
                                        byte[] buffer = new byte[512];
                                        size = fs.Read(buffer, 0, buffer.Length);
                                        ns.Write(buffer, 0, size);
                                        len += size;
                                    }

                                }
                                ShowMsg("�ļ����ͳɹ�");
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

    }
}