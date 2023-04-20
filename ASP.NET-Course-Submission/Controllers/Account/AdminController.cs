using ASP.NET_Course_Submission.Helpers.Services;
using ASP.NET_Course_Submission.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ASP.NET_Course_Submission.Controllers.Account;


public class AdminController : Controller
{
    private readonly UserService _userService;

    public AdminController(UserService userService)
    {
        _userService = userService;
    }

    [Authorize(Roles = "admin")]
    public IActionResult Index()
    {
        return View();
    }

    [Authorize(Roles = "admin")]
    public async Task<IActionResult> GetUsers()
    {
        List<ProfileViewModel> users = (List<ProfileViewModel>)await _userService.Getroles();

        return View(users);
    }
}
