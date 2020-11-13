using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NFine.Data.Extensions;

namespace NFine.Domain.Entity.ShopManage
{
	/// <summary>
	/// Shop_User:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class Shop_UserEntity
	{
		public Shop_UserEntity()
		{ }
		#region Model
		private int _userid;
		private string _username;
		private string _userpassword;
		private long _phone;
		private string _email;
		private string _question;
		private string _answer;
		private DateTime? _createtime;
		private DateTime? _updatetime;
		/// <summary>
		/// 用户ID
		/// </summary>
		public int UserID
		{
			set { _userid = value; }
			get { return _userid; }
		}
		/// <summary>
		/// 用户名
		/// </summary>
		public string UserName
		{
			set { _username = value; }
			get { return _username; }
		}
		/// <summary>
		/// 用户密码
		/// </summary>
		public string UserPassword
		{
			set { _userpassword = value; }
			get { return _userpassword; }
		}
		/// <summary>
		/// 手机
		/// </summary>
		public long Phone
		{
			set { _phone = value; }
			get { return _phone; }
		}
		/// <summary>
		/// 邮箱
		/// </summary>
		public string Email
		{
			set { _email = value; }
			get { return _email; }
		}
		/// <summary>
		/// 密保问题
		/// </summary>
		public string question
		{
			set { _question = value; }
			get { return _question; }
		}
		/// <summary>
		/// 密保答案
		/// </summary>
		public string answer
		{
			set { _answer = value; }
			get { return _answer; }
		}
		/// <summary>
		/// 创建事件
		/// </summary>
		public DateTime? createtime
		{
			set { _createtime = value; }
			get { return _createtime; }
		}
		/// <summary>
		/// 更改时间
		/// </summary>
		public DateTime? updatetime
		{
			set { _updatetime = value; }
			get { return _updatetime; }
		}
		#endregion Model

	}
}
