using Microsoft.AspNetCore.Mvc;

namespace ASP.NET_Course_Submission.Controllers.Account
{
	public class AccountController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
