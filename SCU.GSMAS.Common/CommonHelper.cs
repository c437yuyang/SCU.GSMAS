using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCU.GSMAS.Common
{
    public static class CommonHelper
    {
        public static string cachePath = System.Environment.CurrentDirectory + @"\cache\";
        public static int headerSize = 512;
        public static string serverIp = "127.0.0.1";
        public static int serverPort = 50000;
        public static int recBufSize = 512;
    }
}
