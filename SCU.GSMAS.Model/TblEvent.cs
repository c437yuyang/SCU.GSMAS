/**  版本信息模板在安装目录下，可自行修改。
* TblEvent.cs
*
* 功 能： N/A
* 类 名： TblEvent
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2017/4/28 10:41:07   N/A    初版
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
	/// TblEvent:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class TblEvent
	{
		public TblEvent()
		{}
		#region Model
		private int _evt_id;
		private int _operator_id;
		private int _evt_type;
		private DateTime _evt_time;
		private string _evt_desc;
		/// <summary>
		/// 
		/// </summary>
		public int evt_id
		{
			set{ _evt_id=value;}
			get{return _evt_id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int operator_Id
		{
			set{ _operator_id=value;}
			get{return _operator_id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int evt_type
		{
			set{ _evt_type=value;}
			get{return _evt_type;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime evt_time
		{
			set{ _evt_time=value;}
			get{return _evt_time;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string evt_desc
		{
			set{ _evt_desc=value;}
			get{return _evt_desc;}
		}
		#endregion Model

	}
}

