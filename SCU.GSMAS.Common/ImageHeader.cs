using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCU.GSMAS.Common
{
    

    /// <summary>
    /// 指明图像ID，以及是缩略图还是原图
    /// </summary>
    public struct ImageHeader
    {

        public ImageHeader(int id,int type)
        {
            this.Id = id;
            this.Type = type;
        }

        public static int IMAGE_ORIGIN = 0;
        public static int IMAGE_THUMB = 1;
        public int Id;
        public int Type;
    }



}
