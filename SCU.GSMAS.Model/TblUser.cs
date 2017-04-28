/**  版本信息模板在安装目录下，可自行修改。
* TblUser.cs
*
* 功 能： N/A
* 类 名： TblUser
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2017/4/28 10:41:19   N/A    初版
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
	/// TblUser:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class TblUser
	{
		public TblUser()
		{}
		#region Model
		private int _userid;
		private string _user_no;
		private string _username;
		private string _user_pswd;
		private string _user_question;
		private string _user_answer;
		private int _user_level;
		private DateTime _user_entrydatein;
		private string _user_entryip;
		private DateTime _user_entrydateout;
		private int _user_entrytime;
		private string _user_desc;
		/// <summary>
		/// 
		/// </summary>
		public int userId
		{
			set{ _userid=value;}
			get{return _userid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string user_no
		{
			set{ _user_no=value;}
			get{return _user_no;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string userName
		{
			set{ _username=value;}
			get{return _username;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string user_pswd
		{
			set{ _user_pswd=value;}
			get{return _user_pswd;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string user_question
		{
			set{ _user_question=value;}
			get{return _user_question;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string user_answer
		{
			set{ _user_answer=value;}
			get{return _user_answer;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int user_level
		{
			set{ _user_level=value;}
			get{return _user_level;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime user_entryDateIn
		{
			set{ _user_entrydatein=value;}
			get{return _user_entrydatein;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string user_entryIP
		{
			set{ _user_entryip=value;}
			get{return _user_entryip;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime user_entryDateOut
		{
			set{ _user_entrydateout=value;}
			get{return _user_entrydateout;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int user_entryTime
		{
			set{ _user_entrytime=value;}
			get{return _user_entrytime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string user_desc
		{
			set{ _user_desc=value;}
			get{return _user_desc;}
		}
		#endregion Model

	}
}

