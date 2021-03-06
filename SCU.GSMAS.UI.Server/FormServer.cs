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
        /// 检查是否已经有某张图像的缩略图
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        private bool checkCache(TblImage model, int type)
        {
            string fileName = model.im_path + '/' + model.im_fileName;
            if (type == ImageHeader.IMAGE_ORIGIN)
            {
                return File.Exists(fileName);
            }
            else if (type == ImageHeader.IMAGE_THUMB)
            {
                string thumbName = CommonHelper.getThumbPath(fileName);
                return File.Exists(thumbName);
            }
            else
            {
                return false;
            }
        }

        private void startListening()
        {

            _listener = new TcpListener(IPAddress.Any, int.Parse("50000"));
            _listener.Start();
            ShowMsg("服务器开始监听");

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
                                ns.Read(header, 0, CommonHelper.headerSize); //先读到文件头
                                switch (header[0])
                                {
                                    case (byte)Protocal.MSG_TEXT:
                                        break;
                                    case (byte)Protocal.MSG_IMAGE_ORIGIN:
                                        {
                                            int imgID = BitConverter.ToInt32(header, 1);
                                            TblImage model = bllImg.GetModel(imgID);
                                            string fileName = model.im_path + '/' + model.im_fileName;

                                            ShowMsg("客户端:" + client.Client.RemoteEndPoint.ToString());
                                            ShowMsg("请求原图:" + fileName);
                                            if (!File.Exists(fileName)) //如果文件不存在，返回给客户端信息，文件不存在
                                            {
                                                ShowMsg("原图不存在!");
                                                byte[] buffer = new byte[CommonHelper.headerSize];
                                                buffer[0] = (byte)Protocal.MSG_IMAGE_NOTEXIST;
                                                ns.Write(buffer, 0, CommonHelper.headerSize);
                                                break; //这里千万不能return!,会直接导致整个服务端的监听线程死掉
                                            }

                                            using (FileStream fs = new FileStream(@fileName.ToString(), FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                                            {
                                                byte[] sendHeader = new byte[CommonHelper.headerSize];
                                                sendHeader[0] = (byte)Protocal.MSG_IMAGE_ORIGIN;
                                                byte[] bufFileLen = new byte[4];
                                                bufFileLen = BitConverter.GetBytes(fs.Length);
                                                bufFileLen.CopyTo(sendHeader, 1);
                                                ns.Write(sendHeader, 0, CommonHelper.headerSize);//头文件写入网络
                                                int size = 0;//初始化读取的流量为0   
                                                long len = 0;//初始化已经读取的流量 
                                                while (len < fs.Length)
                                                {
                                                    byte[] buffer = new byte[CommonHelper.recBufSize];
                                                    size = fs.Read(buffer, 0, buffer.Length);
                                                    ns.Write(buffer, 0, size);
                                                    len += size;
                                                }

                                            }
                                            ShowMsg("原图发送成功");
                                            break;
                                        }
                                    case (byte)Protocal.MSG_IMAGE_THUMBNAIL://请求缩略图
                                        {
                                            int imgID = BitConverter.ToInt32(header, 1);
                                            TblImage model = bllImg.GetModel(imgID);
                                            string fileName = model.im_path + '/' + model.im_fileName;
                                            string thumbName = CommonHelper.getThumbPath(fileName);
                                            ShowMsg("客户端:" + client.Client.RemoteEndPoint.ToString());
                                            ShowMsg("请求缩略图:" + fileName);
   
                                            if (!File.Exists(fileName)) //如果文件不存在（原图），返回给客户端信息，文件不存在
                                            {
                                                ShowMsg("原图不存在，无法生成缩略图");
                                                byte[] buffer = new byte[CommonHelper.headerSize];
                                                buffer[0] = (byte)Protocal.MSG_IMAGE_NOTEXIST;
                                                ns.Write(buffer, 0, CommonHelper.headerSize);
                                                break; //这里千万不能return!,会直接导致整个服务端的监听线程死掉
                                            }

                                            if (!checkCache(model, ImageHeader.IMAGE_THUMB)) //如果缩略图不存在则重新创建
                                            {
                                                createThumbNail(fileName, 1, 50, 50);
                                            }

                                            using (FileStream fs = new FileStream(@thumbName.ToString(), FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                                            {
                                                byte[] sendHeader = new byte[CommonHelper.headerSize];
                                                sendHeader[0] = (byte)Protocal.MSG_IMAGE_THUMBNAIL;
                                                byte[] bufFileLen = new byte[4];
                                                bufFileLen = BitConverter.GetBytes(fs.Length);
                                                bufFileLen.CopyTo(sendHeader, 1);
                                                ns.Write(sendHeader, 0, CommonHelper.headerSize);//头文件写入网络
                                                int size = 0;//初始化读取的流量为0   
                                                long len = 0;//初始化已经读取的流量 
                                                while (len < fs.Length)
                                                {
                                                    byte[] buffer = new byte[CommonHelper.recBufSize];
                                                    size = fs.Read(buffer, 0, buffer.Length);
                                                    ns.Write(buffer, 0, size);
                                                    len += size;
                                                }

                                            }
                                            ShowMsg("缩略图发送成功");
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
                    ShowMsg("出现异常：" + ex.Message);
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


        private string createThumbNail(string imgPath, int mode, int width, int height)
        {
            int newH, newW;
            if (mode == 0) //百分比模式
            {
                newH = height;
                newW = width;
            }
            else //指定长宽模式
            {
                newH = height;
                newW = width;
            }

            string thumbPath = CommonHelper.getThumbPath(imgPath);

            ImageHelper.MakeThumbnail(imgPath, thumbPath, newW, newH, "HW");
            return thumbPath;
        }


    }
}