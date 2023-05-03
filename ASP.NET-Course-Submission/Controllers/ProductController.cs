using ASP.NET_Course_Submission.Helpers.Services;
using ASP.NET_Course_Submission.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using System.Data;
using Microsoft.AspNetCore.Mvc;
using ASP.NET_Course_Submission.Models.Entities;

namespace ASP.NET_Course_Submission.Controllers
{
	public class ProductController : Controller
	{
		private readonly ProductService _productService;

		public ProductController(ProductService productService)
		{
			_productService = productService;
		}
		public async Task<IActionResult> Index(string search)
		{
			List<ProductViewModel> products;

			if (string.IsNullOrEmpty(search))
			{
				products = (List<ProductViewModel>)await _productService.GetAllAsync();
			}
			else
			{
				products = (List<ProductViewModel>)await _productService.GetProductByCategory(search);
			}


			return View(products);
		}

		public async Task<IActionResult> Details(int id)
		{

			var product = await _productService.GetAsync(id);
			

			return View(product);
		}
	}
}
