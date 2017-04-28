/**  版本信息模板在安装目录下，可自行修改。
* TblCamera.cs
*
* 功 能： N/A
* 类 名： TblCamera
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2017/4/28 10:40:54   N/A    初版
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
	/// TblCamera:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class TblCamera
	{
		public TblCamera()
		{}
		#region Model
		private int _cam_id;
		private string _cam_name;
		private string _cam_shutter;
		private string _cam_aperture;
		private string _cam_k;
		private string _cam_iso;
		private string _cam_expose;
		private string _cam_desc;
		/// <summary>
		/// 
		/// </summary>
		public int cam_id
		{
			set{ _cam_id=value;}
			get{return _cam_id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string cam_name
		{
			set{ _cam_name=value;}
			get{return _cam_name;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string cam_shutter
		{
			set{ _cam_shutter=value;}
			get{return _cam_shutter;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string cam_aperture
		{
			set{ _cam_aperture=value;}
			get{return _cam_aperture;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string cam_k
		{
			set{ _cam_k=value;}
			get{return _cam_k;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string cam_iso
		{
			set{ _cam_iso=value;}
			get{return _cam_iso;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string cam_expose
		{
			set{ _cam_expose=value;}
			get{return _cam_expose;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string cam_desc
		{
			set{ _cam_desc=value;}
			get{return _cam_desc;}
		}
		#endregion Model

	}
}

