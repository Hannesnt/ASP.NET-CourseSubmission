using ASP.NET_Course_Submission.Helpers.Services;
using ASP.NET_Course_Submission.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace ASP.NET_Course_Submission.Controllers.Account
{
	public class RegisterController : Controller
	{
		private readonly AuthService _authService;

		public RegisterController(AuthService authService)
		{
			_authService = authService;
		}

		public IActionResult Index()
		{
			return View();
		}
		[HttpPost]
		public async Task<IActionResult> Index(RegisterViewModel registerViewModel)
		{
			if(ModelState.IsValid)
			{
				if (await _authService.UserAlreadyExistsAsync(x => x.Email == registerViewModel.Email))
				{

					ModelState.AddModelError("", "A user with the same email already exists");
				}
				else if (await _authService.RegisterAsync(registerViewModel))
				{
					return RedirectToAction("SignIn", "Login");
				}
				else
				{
					ModelState.AddModelError("", "Something went wrong");

				}
			}
			return View(registerViewModel);
		}
	}
}
