

using ASP.NET_Course_Submission.Helpers.Services;
using ASP.NET_Course_Submission.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace ASP.NET_Course_Submission.Controllers.Account
{
	public class LoginController : Controller
	{
		private readonly AuthService _authService;

		public LoginController(AuthService authService)
		{
			_authService = authService;
		}

		public IActionResult Index()
		{
			return View();
		}
		[HttpGet]
		public IActionResult SignIn()
		{
			return View();
		}
		[HttpPost]
			public async Task<IActionResult> SignIn(LoginViewModel model)
			{
				if (ModelState.IsValid)
				{
					if (await _authService.SignInAsync(model))
					{
						return RedirectToAction("Index", "Account");
					}
					else
					{
						ModelState.AddModelError("", "Incorrect email or password");
					}
				}
				return View(model);
			} 
		}
	}
