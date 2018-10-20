using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KillerappToto.ViewModels.Account;
using Microsoft.AspNetCore.Mvc;
using Logic;
using Models;

namespace KillerappToto.Controllers
{
    public class AccountController : Controller
    {
		private AccountLogic AccountLogic = new AccountLogic();

		public IActionResult Login()
        {
            return View();
        }

		[HttpPost]
		public IActionResult Login(LoginViewModel viewModel)
		{
			bool logInCheck = AccountLogic.LoginCheck(viewModel.Email, viewModel.Password);
			if (ModelState.IsValid)
			{
				if (logInCheck)
				{
					User user = AccountLogic.GetUserByEmail(viewModel.Email);

					return RedirectToAction("Index", "Home");
				}
			}

			return View(viewModel);
		}
	}
}