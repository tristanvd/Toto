using System;
using System.Collections.Generic;
using System.Text;
using Data.Context;
using Models;

namespace Logic
{
	public class AccountLogic
	{
		AccountContext AccountContext = new AccountContext();
		public bool LoginCheck(string eMail, string passWord)
		{
			return AccountContext.LoginCheck(eMail, passWord);
		}

		public User GetUserByEmail(string eMail)
		{
			return AccountContext.GetUserByEmail(eMail);
		}
	}
}
