using ASP.NET_Course_Submission.Helpers.Repositories.ContextRepos;
using ASP.NET_Course_Submission.Helpers.Services;
using ASP.NET_Course_Submission.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ASP.NET_Course_Submission.Controllers.Account;


public class AdminController : Controller
{
    private readonly UserService _userService;
    private readonly AdminService _adminService;
	private readonly ProductService _productService;
    private readonly ProductRepository _productRepository;
    private readonly CategoryService _categoryService;
	private readonly TagService _tagService;
	public AdminController(UserService userService, AdminService adminService, ProductService productService, ProductRepository productRepository, CategoryService categoryService, TagService tagService)
	{
		_userService = userService;
		_adminService = adminService;
		_productService = productService;
		_productRepository = productRepository;
		_categoryService = categoryService;
		_tagService = tagService;
	}

	[Authorize(Roles = "admin")]
    public IActionResult Index()
    {
        return View();
    }

    [Authorize(Roles = "admin")]
	[HttpGet]
	public async Task<IActionResult> GetUsers()
    {
        List<ProfileViewModel> users = (List<ProfileViewModel>)await _userService.GetUserAsync();

        return View(users);
    }
    [Authorize(Roles = "admin")]
    [HttpPost]
    public async Task<IActionResult> GetUsers(ProfileViewModel model)
    {
        if (ModelState.IsValid)
        {
            if(await _adminService.AdminChangeRole(model))
            {
                return RedirectToAction("GetUsers", "Admin");
			}
            else
            {
                return RedirectToAction("GetUsers", "Admin");
            }
        }
        return View(model);
    }


	[Authorize(Roles = "admin")]
	[HttpGet]
	public IActionResult CreateUser()
	{

		return View();
	}


	[Authorize(Roles = "admin")]
    [HttpPost]
	public async Task<IActionResult> CreateUser(AdminRegUserViewModel model)
    {
        if(ModelState.IsValid)
        {
            if(await _adminService.AdminRegisterAsync(model))
            {
                return RedirectToAction("GetUsers", "Admin");
            }
            else
            {
                ModelState.AddModelError("", "A user with the same email already exists");
            }
        }
        return View(model);
    }
	[Authorize(Roles = "admin")]
	[HttpGet]
	public async Task<IActionResult> CreateProduct()
	{
		ViewBag.Tags = await _tagService.GetTagsAsync();
		return View();
	}


	[Authorize(Roles = "admin")]
	[HttpPost]
	public async Task<IActionResult> CreateProduct(RegisterProductViewModel model, string[] tags)
	{
		if (ModelState.IsValid)
		{
			if (await _productService.CreateAsync(model))
			{
				await _productService.AddProductTagsAsync(model, tags);
				return RedirectToAction("GetProducts", "Admin");
			}
			ModelState.AddModelError("", "Product already exists.");
		}
		ViewBag.Tags = await _tagService.GetTagsAsync(tags);
		return View();
	}

    [Authorize(Roles = "admin")]
    [HttpGet]
    public async Task<IActionResult> GetProducts()
    {
        var products = (List<ProductViewModel>)await _productService.GetAllAsync();

        return View(products);
    }

	[Authorize(Roles = "admin")]
	[HttpPost]
	public async Task<IActionResult> GetProducts(ProductViewModel model)
	{
        if(ModelState.IsValid)
        {
            if(await _adminService.EditProductAsync(model))
			{
				return RedirectToAction("GetProducts", "Admin");
			}
			else
			{
				return RedirectToAction("GetProducts", "Admin");
			}
		}
		else
		{
			return RedirectToAction("GetProducts", "Admin");
		}
		
	}
	public async Task<IActionResult> RemoveProduct(ProductViewModel model)
	{
		
		if(await _productService.RemoveProductAsync(model))
		{
			return RedirectToAction("GetProducts", "Admin");
		}
		else
		{
			return RedirectToAction("GetProducts", "Admin");
		}
	}
}
