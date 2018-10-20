using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using Models;

namespace Data.Context
{
	public class MatchContext
	{
		private string ConnectionString { get; set; } = "Data Source=DESKTOP-38T55SN;Initial Catalog=Toto;User ID=sa;Password=784512tyghvB;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";


		public List<Match> GetAllUnplayedMatches()
		{
			List<Match> matches = new List<Match>();
			string query = "SELECT * FROM Match where Played = 'false'";
			using (var conn = new SqlConnection(ConnectionString))
			{
				conn.Open();
				using (var cmd = new SqlCommand(query, conn))
				{
					using (var reader = cmd.ExecuteReader())
					{
						if (reader.HasRows)
						{
							while (reader.Read())
							{
								Match match = new Match()
								{
									Id = (int)reader["Id"],
									HomeTeam = (string)reader["HomeTeam"],
									AwayTeam = (string)reader["AwayTeam"],
									HomeTeamOdd = (decimal)reader["HomeOdd"],
									XOdd = (decimal)reader["XOdd"],
									AwayTeamOdd = (decimal)reader["AwayOdd"],
									Date = (DateTime)reader["Date"]
								};
								matches.Add(match);
							}
						}
					}
				}

				return matches;
			}
		}
	}
}
