using ASP.NET_Course_Submission.Helpers.Services;
using ASP.NET_Course_Submission.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using System.Data;
using Microsoft.AspNetCore.Mvc;

namespace ASP.NET_Course_Submission.Controllers
{
	public class ProductController : Controller
	{
		private readonly ProductService _productService;

		public ProductController(ProductService productService)
		{
			_productService = productService;
		}
		public async Task<IActionResult> Index()
		{
			List<ProductViewModel> products;

			products = (List<ProductViewModel>)await _productService.GetAllAsync();

			return View(products);
		}


	}
}
