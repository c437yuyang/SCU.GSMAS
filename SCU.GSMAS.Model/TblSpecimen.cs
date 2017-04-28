/**  版本信息模板在安装目录下，可自行修改。
* TblSpecimen.cs
*
* 功 能： N/A
* 类 名： TblSpecimen
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2017/4/28 10:41:16   N/A    初版
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
	/// TblSpecimen:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class TblSpecimen
	{
		public TblSpecimen()
		{}
		#region Model
		private int _sp_id;
		private string _sp_no;
		private string _sp_name;
		private string _sp_desc;
		private int _field_id;
		private int _category_id;
		/// <summary>
		/// 
		/// </summary>
		public int sp_id
		{
			set{ _sp_id=value;}
			get{return _sp_id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string sp_no
		{
			set{ _sp_no=value;}
			get{return _sp_no;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string sp_name
		{
			set{ _sp_name=value;}
			get{return _sp_name;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string sp_desc
		{
			set{ _sp_desc=value;}
			get{return _sp_desc;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int field_id
		{
			set{ _field_id=value;}
			get{return _field_id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int category_id
		{
			set{ _category_id=value;}
			get{return _category_id;}
		}
        #endregion Model
        public override string ToString()
        {
            return this.sp_name;
        }
    }
}

