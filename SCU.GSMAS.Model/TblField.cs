/**  版本信息模板在安装目录下，可自行修改。
* TblField.cs
*
* 功 能： N/A
* 类 名： TblField
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2017/4/28 10:41:10   N/A    初版
*
* Copyright (c) 2012 Maticsoft Corporation. All rights reserved.
*┌──────────────────────────────────┐
*│　此技术信息为本公司机密信息，未经本公司书面同意禁止向第三方披露．　│
*│　版权所有：动软卓越（北京）科技有限公司　　　　　　　　　　　　　　│
*└──────────────────────────────────┘
*/
using System;
namespace SCU.GSMAS.Model
{
	/// <summary>
	/// TblField:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class TblField
	{
		public TblField()
		{}
		#region Model
		private int _fd_id;
		private string _fd_name;
		private string _fd_addr;
		private string _fd_desc;
		/// <summary>
		/// 
		/// </summary>
		public int fd_id
		{
			set{ _fd_id=value;}
			get{return _fd_id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string fd_name
		{
			set{ _fd_name=value;}
			get{return _fd_name;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string fd_addr
		{
			set{ _fd_addr=value;}
			get{return _fd_addr;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string fd_desc
		{
			set{ _fd_desc=value;}
			get{return _fd_desc;}
		}
        #endregion Model

        public override string ToString()
        {
            return this.fd_name;
        }

    }
}

