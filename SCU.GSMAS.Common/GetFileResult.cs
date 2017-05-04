using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCU.GSMAS.Common
{
    public enum GetFileResult : byte
    {
        FileNotExist, //请求文件不存在
        FileExist //文件存在
    }
}
