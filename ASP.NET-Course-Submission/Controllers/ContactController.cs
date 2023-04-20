using ASP.NET_Course_Submission.Helpers.Services;
using ASP.NET_Course_Submission.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace ASP.NET_Course_Submission.Controllers
{
	public class ContactController : Controller
	{
		private readonly ContactUsService _contactUsService;

        public ContactController(ContactUsService contactUsService)
        {
            _contactUsService = contactUsService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
		public async Task <IActionResult> Index(ContactUsViewModel model)
		{
            if(ModelState.IsValid)
            {
                if (await _contactUsService.RegisterContactUser(model))
                    return LocalRedirect("/");
            }
            else
            {
                ModelState.AddModelError("", "Something went wrong");
            }
            return View(model);
        }
	}
}
