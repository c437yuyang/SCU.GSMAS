using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCU.GSMAS.Common
{
    public static class CommonHelper
    {
        public static string cachePath = System.Environment.CurrentDirectory + @"\cache\"; //带前\带后\
        public static int headerSize = 512;
        public static string serverIp = "127.0.0.1";
        public static int serverPort = 50000;
        public static int recBufSize = 512;

        /// <summary>
        /// 给定指定图像路径，生成对应缩略图路径
        /// </summary>
        /// <param name="originImagePath"></param>
        /// <returns></returns>
        public static string getThumbPath(string originImagePath)
        {
            return originImagePath.Insert(originImagePath.LastIndexOf('.'), "_thumb");
        }

    }
}
