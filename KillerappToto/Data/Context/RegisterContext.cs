using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;


namespace Data.Context
{
	public class RegisterContext
	{

		private string ConnectionString { get; set; } = "Data Source=DESKTOP-38T55SN;Initial Catalog=Toto;User ID=sa;Password=784512tyghvB;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

		public void Register(string email, string password, string username)
		{
			string query = $"INSERT INTO [User](Email, Password, Username) VALUES(@Email, @Password, @Username)";

			using (SqlConnection conn = new SqlConnection(this.ConnectionString))
			{
				using (SqlCommand cmd = new SqlCommand(query, conn))
				{
					cmd.Parameters.Add(new SqlParameter("@Email", email));
					cmd.Parameters.Add(new SqlParameter("@Password", password));
					cmd.Parameters.Add(new SqlParameter("@Username", username));
					
					conn.Open();
					cmd.ExecuteNonQuery();
					conn.Close();
				}
			}
		}

	}
}
