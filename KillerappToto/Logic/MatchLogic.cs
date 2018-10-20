using System;
using System.Collections.Generic;
using System.Text;
using Models;
using Data.Context;

namespace Logic
{
	public class MatchLogic
	{
		MatchContext MatchContext = new MatchContext();

		public List<Match> GetAllUnplayedMatches()
		{
			return MatchContext.GetAllUnplayedMatches();
		}
	}
}
