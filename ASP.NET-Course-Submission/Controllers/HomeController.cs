using ASP.NET_Course_Submission.Helpers.Services;
using ASP.NET_Course_Submission.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace ASP.NET_Course_Submission.Controllers
{
	public class HomeController : Controller
	{
		private readonly ProductService _productService;
		private readonly CategoryService _categoryService;

		public HomeController(ProductService productService, CategoryService categoryService)
		{
			_productService = productService;
			_categoryService = categoryService;
		}
		public async Task<IActionResult> Index(string search)
		{
			List<ProductViewModel> products;

			products = (List<ProductViewModel>)await _productService.GetAllAsync();
			var model = new Tuple<List<ProductViewModel>, string>(products, search);
			return View(model);
		}
	}
}
