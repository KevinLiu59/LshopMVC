using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using NFine.Domain.Entity.ShopManage;
using Maticsoft.DBUtility;
using NFine.Code;
using System.Security.Cryptography;

namespace NFine.Application.ShopManage
{
   public class ShopUserApp
    {
		/// <summary>
		/// 数据访问类:Shop_User
		/// </summary>
		public partial class Shop_User
		{
			public Shop_User()
			{ }
			#region  BasicMethod
			/// <summary>
			/// 是否存在该记录
			/// </summary>
			public bool Exists(int UserID)
			{
				StringBuilder strSql = new StringBuilder();
				strSql.Append("select count(1) from Shop_User");
				strSql.Append(" where UserID=@UserID");
				SqlParameter[] parameters = {
					new SqlParameter("@UserID", SqlDbType.Int,4)
			};
				parameters[0].Value = UserID;

				return DbHelperSQL.Exists(strSql.ToString(), parameters);
			}


			/// <summary>
			/// 增加一条数据
			/// </summary>
			public int Add(Shop_UserEntity model)
			{
				StringBuilder strSql = new StringBuilder();
				strSql.Append("insert into Shop_User(");
				strSql.Append("UserName,UserPassword,Phone,Email,question,answer,createtime,updatetime)");
				strSql.Append(" values (");
				strSql.Append("@UserName,@UserPassword,@Phone,@Email,@question,@answer,@createtime,@updatetime)");
				strSql.Append(";select @@IDENTITY");
				SqlParameter[] parameters = {
					new SqlParameter("@UserName", SqlDbType.VarChar,50),
					new SqlParameter("@UserPassword", SqlDbType.VarChar,50),
					new SqlParameter("@Phone", SqlDbType.BigInt,8),
					new SqlParameter("@Email", SqlDbType.VarChar,100),
					new SqlParameter("@question", SqlDbType.VarChar,100),
					new SqlParameter("@answer", SqlDbType.VarChar,100),
					new SqlParameter("@createtime", SqlDbType.DateTime),
					new SqlParameter("@updatetime", SqlDbType.DateTime)};
				parameters[0].Value = model.UserName;
				parameters[1].Value = model.UserPassword;
				parameters[2].Value = model.Phone;
				parameters[3].Value = model.Email;
				parameters[4].Value = model.question;
				parameters[5].Value = model.answer;
				parameters[6].Value = model.createtime;
				parameters[7].Value = model.updatetime;

				object obj = DbHelperSQL.GetSingle(strSql.ToString(), parameters);
				if (obj == null)
				{
					return 0;
				}
				else
				{
					return Convert.ToInt32(obj);
				}
			}
			/// <summary>
			/// 更新一条数据
			/// </summary>
			public bool Update(Shop_UserEntity model)
			{
				StringBuilder strSql = new StringBuilder();
				strSql.Append("update Shop_User set ");
				strSql.Append("UserName=@UserName,");
				strSql.Append("UserPassword=@UserPassword,");
				strSql.Append("Phone=@Phone,");
				strSql.Append("Email=@Email,");
				strSql.Append("question=@question,");
				strSql.Append("answer=@answer,");
				strSql.Append("createtime=@createtime,");
				strSql.Append("updatetime=@updatetime");
				strSql.Append(" where UserID=@UserID");
				SqlParameter[] parameters = {
					new SqlParameter("@UserName", SqlDbType.VarChar,50),
					new SqlParameter("@UserPassword", SqlDbType.VarChar,50),
					new SqlParameter("@Phone", SqlDbType.BigInt,8),
					new SqlParameter("@Email", SqlDbType.VarChar,100),
					new SqlParameter("@question", SqlDbType.VarChar,100),
					new SqlParameter("@answer", SqlDbType.VarChar,100),
					new SqlParameter("@createtime", SqlDbType.DateTime),
					new SqlParameter("@updatetime", SqlDbType.DateTime),
					new SqlParameter("@UserID", SqlDbType.Int,4)};
				parameters[0].Value = model.UserName;
				parameters[1].Value = model.UserPassword;
				parameters[2].Value = model.Phone;
				parameters[3].Value = model.Email;
				parameters[4].Value = model.question;
				parameters[5].Value = model.answer;
				parameters[6].Value = model.createtime;
				parameters[7].Value = model.updatetime;
				parameters[8].Value = model.UserID;

				int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
				if (rows > 0)
				{
					return true;
				}
				else
				{
					return false;
				}
			}

			/// <summary>
			/// 删除一条数据
			/// </summary>
			public bool Delete(int UserID)
			{

				StringBuilder strSql = new StringBuilder();
				strSql.Append("delete from Shop_User ");
				strSql.Append(" where UserID=@UserID");
				SqlParameter[] parameters = {
					new SqlParameter("@UserID", SqlDbType.Int,4)
			};
				parameters[0].Value = UserID;

				int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
				if (rows > 0)
				{
					return true;
				}
				else
				{
					return false;
				}
			}
			/// <summary>
			/// 批量删除数据
			/// </summary>
			public bool DeleteList(string UserIDlist)
			{
				StringBuilder strSql = new StringBuilder();
				strSql.Append("delete from Shop_User ");
				strSql.Append(" where UserID in (" + UserIDlist + ")  ");
				int rows = DbHelperSQL.ExecuteSql(strSql.ToString());
				if (rows > 0)
				{
					return true;
				}
				else
				{
					return false;
				}
			}


			/// <summary>
			/// 得到一个对象实体
			/// </summary>
			public Shop_UserEntity GetModel(int UserID)
			{

				StringBuilder strSql = new StringBuilder();
				strSql.Append("select  top 1 UserID,UserName,UserPassword,Phone,Email,question,answer,createtime,updatetime from Shop_User ");
				strSql.Append(" where UserID=@UserID");
				SqlParameter[] parameters = {
					new SqlParameter("@UserID", SqlDbType.Int,4)
			};
				parameters[0].Value = UserID;

				Shop_UserEntity model = new Shop_UserEntity();
				DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
				if (ds.Tables[0].Rows.Count > 0)
				{
					return DataRowToModel(ds.Tables[0].Rows[0]);
				}
				else
				{
					return null;
				}
			}


			/// <summary>
			/// 得到一个对象实体
			/// </summary>
			public Shop_UserEntity DataRowToModel(DataRow row)
			{
				Shop_UserEntity model = new Shop_UserEntity();
				if (row != null)
				{
					if (row["UserID"] != null && row["UserID"].ToString() != "")
					{
						model.UserID = int.Parse(row["UserID"].ToString());
					}
					if (row["UserName"] != null)
					{
						model.UserName = row["UserName"].ToString();
					}
					if (row["UserPassword"] != null)
					{
						model.UserPassword = row["UserPassword"].ToString();
					}
					if (row["Phone"] != null && row["Phone"].ToString() != "")
					{
						model.Phone = long.Parse(row["Phone"].ToString());
					}
					if (row["Email"] != null)
					{
						model.Email = row["Email"].ToString();
					}
					if (row["question"] != null)
					{
						model.question = row["question"].ToString();
					}
					if (row["answer"] != null)
					{
						model.answer = row["answer"].ToString();
					}
					if (row["createtime"] != null && row["createtime"].ToString() != "")
					{
						model.createtime = DateTime.Parse(row["createtime"].ToString());
					}
					if (row["updatetime"] != null && row["updatetime"].ToString() != "")
					{
						model.updatetime = DateTime.Parse(row["updatetime"].ToString());
					}
				}
				return model;
			}

			/// <summary>
			/// 检查登录
			/// </summary>
			/// <param name="UserName">用户名</param>
			/// <param name="Password">密码</param>
			/// <returns>用户ID</returns>
			public int CheckLogin(string UserName, string Password)
			{
				string md5p = Md5.md5(Password, 32);
				string where = @"username='" + UserName + "' and userpassword='" + md5p + "'";

				try {
					DataSet ds = GetList(where);
					int Userid = ds.Tables[0].Rows[0]["UserID"].ToInt();
					return Userid;
				}
				catch
				{
					return 0;
				}
			}

			/// <summary>
			/// 获得数据列表
			/// </summary>
			public DataSet GetList(string strWhere)
			{
				StringBuilder strSql = new StringBuilder();
				strSql.Append("select UserID,UserName,UserPassword,Phone,Email,question,answer,createtime,updatetime ");
				strSql.Append(" FROM Shop_User ");
				if (strWhere.Trim() != "")
				{
					strSql.Append(" where " + strWhere);
				}
				return DbHelperSQL.Query(strSql.ToString());
			}

			/// <summary>
			/// 获得前几行数据
			/// </summary>
			public DataSet GetList(int Top, string strWhere, string filedOrder)
			{
				StringBuilder strSql = new StringBuilder();
				strSql.Append("select ");
				if (Top > 0)
				{
					strSql.Append(" top " + Top.ToString());
				}
				strSql.Append(" UserID,UserName,UserPassword,Phone,Email,question,answer,createtime,updatetime ");
				strSql.Append(" FROM Shop_User ");
				if (strWhere.Trim() != "")
				{
					strSql.Append(" where " + strWhere);
				}
				strSql.Append(" order by " + filedOrder);
				return DbHelperSQL.Query(strSql.ToString());
			}

			/// <summary>
			/// 获取记录总数
			/// </summary>
			public int GetRecordCount(string strWhere)
			{
				StringBuilder strSql = new StringBuilder();
				strSql.Append("select count(1) FROM Shop_User ");
				if (strWhere.Trim() != "")
				{
					strSql.Append(" where " + strWhere);
				}
				object obj = DbHelperSQL.GetSingle(strSql.ToString());
				if (obj == null)
				{
					return 0;
				}
				else
				{
					return Convert.ToInt32(obj);
				}
			}
			/// <summary>
			/// 分页获取数据列表
			/// </summary>
			public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
			{
				StringBuilder strSql = new StringBuilder();
				strSql.Append("SELECT * FROM ( ");
				strSql.Append(" SELECT ROW_NUMBER() OVER (");
				if (!string.IsNullOrEmpty(orderby.Trim()))
				{
					strSql.Append("order by T." + orderby);
				}
				else
				{
					strSql.Append("order by T.UserID desc");
				}
				strSql.Append(")AS Row, T.*  from Shop_User T ");
				if (!string.IsNullOrEmpty(strWhere.Trim()))
				{
					strSql.Append(" WHERE " + strWhere);
				}
				strSql.Append(" ) TT");
				strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
				return DbHelperSQL.Query(strSql.ToString());
			}

			/*
			/// <summary>
			/// 分页获取数据列表
			/// </summary>
			public DataSet GetList(int PageSize,int PageIndex,string strWhere)
			{
				SqlParameter[] parameters = {
						new SqlParameter("@tblName", SqlDbType.VarChar, 255),
						new SqlParameter("@fldName", SqlDbType.VarChar, 255),
						new SqlParameter("@PageSize", SqlDbType.Int),
						new SqlParameter("@PageIndex", SqlDbType.Int),
						new SqlParameter("@IsReCount", SqlDbType.Bit),
						new SqlParameter("@OrderType", SqlDbType.Bit),
						new SqlParameter("@strWhere", SqlDbType.VarChar,1000),
						};
				parameters[0].Value = "Shop_User";
				parameters[1].Value = "UserID";
				parameters[2].Value = PageSize;
				parameters[3].Value = PageIndex;
				parameters[4].Value = 0;
				parameters[5].Value = 0;
				parameters[6].Value = strWhere;	
				return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
			}*/

			#endregion  BasicMethod
			#region  ExtensionMethod

			#endregion  ExtensionMethod

			/// <summary>
			/// 检查登录状态，用户填充前端用户名
			/// </summary>
			/// <returns></returns>
			public static string CheckLoginState(string un)
			{
				if (un != "Login")
				{
					return un;
				}
				return "Login";
			}
		}
	}
}
