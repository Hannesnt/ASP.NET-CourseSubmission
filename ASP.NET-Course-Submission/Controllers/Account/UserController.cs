using ASP.NET_Course_Submission.Helpers.Repositories.IdentityRepos;
using ASP.NET_Course_Submission.Helpers.Services;
using ASP.NET_Course_Submission.Models.Context;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ASP.NET_Course_Submission.Controllers.Account
{
    public class UserController : Controller
    {
        private readonly UserService _userService;

        public UserController(UserService userService)
        {
            _userService = userService;

        }

        [Route("Myaccount")]
        public async Task<IActionResult> Index()
        {
            
            var user = await _userService.CurrentUser(User);
            ViewData["Title"] = user.FirstName;
            return View(user);
        }
    }
}
