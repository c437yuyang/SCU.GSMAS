/**  版本信息模板在安装目录下，可自行修改。
* TblCategory.cs
*
* 功 能： N/A
* 类 名： TblCategory
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2017/4/28 10:41:04   N/A    初版
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
	/// TblCategory:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class TblCategory
	{
		public TblCategory()
		{}
		#region Model
		private int _cat_id;
		private string _cat_name;
		private string _cat_desc;
		/// <summary>
		/// 
		/// </summary>
		public int cat_id
		{
			set{ _cat_id=value;}
			get{return _cat_id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string cat_name
		{
			set{ _cat_name=value;}
			get{return _cat_name;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string cat_desc
		{
			set{ _cat_desc=value;}
			get{return _cat_desc;}
		}
		#endregion Model

	}
}

