/**  版本信息模板在安装目录下，可自行修改。
* TblImage.cs
*
* 功 能： N/A
* 类 名： TblImage
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2017/4/28 10:41:12   N/A    初版
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
	/// TblImage:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class TblImage
	{
		public TblImage()
		{}
		#region Model
		private int _im_id;
		private string _im_path;
		private string _im_filename;
		private DateTime _im_time;
		private int? _im_resolution;
		private int? _im_savelevel;
		private int? _cam_id;
		private int? _sp_id;
		private int _userid;
		/// <summary>
		/// 
		/// </summary>
		public int im_id
		{
			set{ _im_id=value;}
			get{return _im_id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string im_path
		{
			set{ _im_path=value;}
			get{return _im_path;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string im_fileName
		{
			set{ _im_filename=value;}
			get{return _im_filename;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime im_time
		{
			set{ _im_time=value;}
			get{return _im_time;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? im_resolution
		{
			set{ _im_resolution=value;}
			get{return _im_resolution;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? im_saveLevel
		{
			set{ _im_savelevel=value;}
			get{return _im_savelevel;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? cam_id
		{
			set{ _cam_id=value;}
			get{return _cam_id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? sp_id
		{
			set{ _sp_id=value;}
			get{return _sp_id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int userId
		{
			set{ _userid=value;}
			get{return _userid;}
		}
		#endregion Model

	}
}

