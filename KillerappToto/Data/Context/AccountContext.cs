using Models;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Text;

namespace Data.Context
{
	public class AccountContext
	{

		private string ConnectionString { get; set; } = "Data Source=DESKTOP-38T55SN;Initial Catalog=Toto;User ID=sa;Password=784512tyghvB;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";


		public bool LoginCheck(string email, string password)
		{
			string query = $"SELECT Email, Password FROM [User] WHERE Email=@Email AND Password=@Password";
			bool logInIsValid = false;

			using (SqlConnection conn = new SqlConnection(this.ConnectionString))
			{
				using (SqlCommand cmd = new SqlCommand(query, conn))
				{
					cmd.Parameters.Add(new SqlParameter("@Email", email));
					cmd.Parameters.Add(new SqlParameter("@Password", password));
					conn.Open();

					foreach (DbDataRecord record in cmd.ExecuteReader())
					{
						logInIsValid = true;
					}

					
				}
			}

			return logInIsValid;
		}

		public User GetUserByEmail(string email)
		{
			User user = new User();
			string query = $"SELECT Id, Email, Username, Balance FROM [User] WHERE Email=@Email";

			using (SqlConnection conn = new SqlConnection(this.ConnectionString))
			{
				using (SqlCommand cmd = new SqlCommand(query, conn))
				{
					cmd.Parameters.Add(new SqlParameter("@Email", email));
					conn.Open();
					foreach (DbDataRecord record in cmd.ExecuteReader())
					{
						user = new User()
						{
							Id = record.GetInt32(record.GetOrdinal("Id")),
							Username = record.GetString(record.GetOrdinal("Username")),
							Email = record.GetString(record.GetOrdinal("Email")),
							Balance = record.GetDecimal(record.GetOrdinal("Balance")),
						};
					}
				}
			}

			return user;
		}
	}
}
