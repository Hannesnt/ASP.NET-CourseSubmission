using ASP.NET_Course_Submission.Helpers.Services;
using ASP.NET_Course_Submission.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using System.Data;
using Microsoft.AspNetCore.Mvc;
using ASP.NET_Course_Submission.Models.Entities;
using System.Text.Json;

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

			var cookies = _productService.GetCookies();

			var productList = new List<ProductViewModel>(cookies);

			var checkProduct = productList.FirstOrDefault(x => x.Id == product.Id);
			if (checkProduct != null)
			{
				productList.Remove(checkProduct);
			}
			if (productList.Count == 3)
			{
				productList.Remove(productList[0]);
			}

			productList.Add(product);

			var Json = JsonSerializer.Serialize(productList);

			CookieOptions options = new CookieOptions();
			options.Expires = DateTimeOffset.Now.AddDays(1);


			if (productList != null)
			{
					Response.Cookies.Append("VisitedProducts", Json, options);
			}

			return View(product);
		}
	}
}
