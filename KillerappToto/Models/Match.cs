using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
	public class Match
	{
		public int Id { get; set; }
		public string HomeTeam { get; set; }
		public decimal HomeTeamOdd { get; set; }
		public decimal XOdd { get; set; }
		public string AwayTeam { get; set; }
		public decimal AwayTeamOdd { get; set; }
		public DateTime Date { get; set; }
		

	}
}
