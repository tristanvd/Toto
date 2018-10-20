using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KillerappToto.ViewModels.Account;
using Logic;
using Microsoft.AspNetCore.Mvc;

namespace KillerappToto.Controllers
{
    public class RegisterController : Controller
    {
		private RegisterLogic registerLogic = new RegisterLogic();

		public IActionResult Register()
		{
			return View();
		}

		[HttpPost]
		public IActionResult Register(RegisterViewModel viewModel)
		{
			registerLogic.RegisterUser(viewModel.Email, viewModel.Password, viewModel.Username);
			return RedirectToAction("Index", "Home");
		}
	}
}