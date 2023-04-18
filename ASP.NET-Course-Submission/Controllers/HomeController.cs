using Microsoft.AspNetCore.Mvc;

namespace ASP.NET_Course_Submission.Controllers
{
	public class HomeController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
