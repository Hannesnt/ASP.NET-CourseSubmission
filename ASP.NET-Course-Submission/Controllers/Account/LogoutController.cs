using ASP.NET_Course_Submission.Helpers.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ASP.NET_Course_Submission.Controllers.Account
{
	public class LogoutController : Controller
	{
        private readonly AuthService _authService;

        public LogoutController(AuthService authService)
        {
            _authService = authService;
        }
        [Authorize]
        public new async Task<IActionResult> SignOut()
        {
            if (await _authService.SignOutAsync(User))
                return RedirectToAction("Index", "Home");

            return RedirectToAction("Index", "Home");


        }
    }
}
