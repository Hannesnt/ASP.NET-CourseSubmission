using System.Linq.Expressions;
using ASP.NET_Course_Submission.Helpers.Repositories.ContextRepos;
using ASP.NET_Course_Submission.Models.Context;
using ASP.NET_Course_Submission.Models.Entities;
using ASP.NET_Course_Submission.Models.ViewModels;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace ASP.NET_Course_Submission.Helpers.Services
{
	public class ProductService
	{
		private readonly DataContext _context;
		private readonly ProductRepository _repository;
		private readonly CategoryService _categoryService;
        public ProductService(DataContext context, ProductRepository repository, CategoryService categoryService)
        {
            _context = context;
            _repository = repository;
            _categoryService = categoryService;
        }
        public async Task<bool> CreateAsync(RegisterProductViewModel model)
		{
			try
			{
				await _repository.CreateAsync(model);
				return true;
			}
			catch
			{
				return false;
			}
		}
		public async Task<IEnumerable<ProductViewModel>> GetAllAsync()
		{
			var products = new List<ProductViewModel>();
			var items = await _context.Products.ToListAsync();
			foreach (var item in items)
			{
				ProductViewModel productModel = item;
				products.Add(productModel);
			}
			return products;
		}

        public async Task<ProductViewModel> GetAsync(int id)
		{

			var product = await _repository.GetAsync(x => x.Id == id);

			return product;
		}
		public async Task<IEnumerable<ProductViewModel>> GetProductByCategory(string name)
		{
			var products = new List<ProductViewModel>();
			var items = await _context.Products.OrderByDescending(p => p.Id).Include(x => x.Category).Where(x => x.Category.CategoryName == name).ToListAsync();
			foreach (var item in items)
			{
				ProductViewModel productModel = item;
				products.Add(productModel);
			}
			return products;
		}
        public async Task<List<ProductViewModel>> GetProductByCategoryTagNew(string name)
        {
            var products = new List<ProductViewModel>();
            var items = await _context.Products.OrderByDescending(p => p.Id).Include(x => x.Category).Where(x => x.Category.CategoryName == name).ToListAsync();
            foreach (var item in items)
            {
				if(item.New == true)
				{
                    ProductViewModel productModel = item;
                    products.Add(productModel);
                }
            }
            return products;
        }
        public async Task<List<ProductViewModel>> DiscoverProductsAsync()
        {
            var products = new List<ProductViewModel>();
			var random = new Random();
			string categoryName = "";
			int category = 0;
			var categories = await _context.Categories.ToListAsync();
			var items = new List<ProductEntity>();
			do
			{
				category = random.Next(categories.Count);
				categoryName = await _categoryService.GetCategoryName(category);
				items = await _context.Products.OrderByDescending(p => p.Id).Include(x => x.Category).Where(x => x.Category.Id == category).ToListAsync();

			}
			while (!items.Any());
			var randomItems = items.OrderBy(x => random.Next()).Take(3);
            foreach (var item in randomItems)
            {

				ProductViewModel productModel = new ProductViewModel
				{
					Id = item.Id,
					Name = item.Name,
					Description = item.Description!,
					Price = item.Price,
					Discount = item.Discount,
					CategoryId = category,
					ProductImage = item.ProductImage,
					New = item.New,
					Featured = item.Featured,
					Popular = item.Popular,
					OnSale = item.OnSale,
					CategoryName = categoryName

				};
                    products.Add(productModel);
                
            }
            return products;
        }

        public async Task<ProductViewModel> ShowCaseProduct()
		{
			var random = new Random();
			var product = await _context.Products.Where(x => x.Featured == true).ToListAsync();
			var index = random.Next(product.Count);

			return product[index];
		}

	}
}
