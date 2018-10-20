using System;
using Data.Context;

namespace Logic
{
	public class RegisterLogic
	{
		RegisterContext registerContext = new RegisterContext();
		public void RegisterUser(string email, string password, string username)
		{
			registerContext.Register(email, password, username);
		}
	}
}
