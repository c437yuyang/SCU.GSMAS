using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCU.GSMAS.Common
{
    /// <summary>
    /// 服务端与客户端通信协议
    /// </summary>
    public enum Protocal : byte
    {
        MSG_TEXT,
        MSG_IMAGE_THUMBNAIL,
        MSG_IMAGE_ORIGIN,
        MSG_IMAGE_NOTEXIST
    }
}
