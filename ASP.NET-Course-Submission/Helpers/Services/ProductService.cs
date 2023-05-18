
using System.Text.Json;
using ASP.NET_Course_Submission.Helpers.Repositories.ContextRepos;
using ASP.NET_Course_Submission.Migrations.Data;
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
		private readonly IHttpContextAccessor _httpContextAccessor;
		private readonly ProductTagRepository _productTagRepository;
		private readonly TagRepository _tagRepository;
		public ProductService(DataContext context, ProductRepository repository, CategoryService categoryService, IHttpContextAccessor httpContextAccessor, ProductTagRepository productTagRepository, TagRepository tagRepository)
		{
			_context = context;
			_repository = repository;
			_categoryService = categoryService;
			_httpContextAccessor = httpContextAccessor;
			_productTagRepository = productTagRepository;
			_tagRepository = tagRepository;
		}
		public async Task<bool> CreateAsync(RegisterProductViewModel model)
		{
			try
			{
				if(await _repository.GetAsync(x => x.Name == model.Name) == null)
				{
                    await _repository.CreateAsync(model);
                    return true;
                }

				return false;
			}
			catch
			{
				return false;
			}
		}
		public async Task<List<ProductViewModel>> GetAllAsync()
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

		public async Task<List<ProductViewModel>> GetProductByCategory(string name)
		{
			var products = new List<ProductViewModel>();
            var items = await _repository.GetAllAsync();
            var category = await _categoryService.GetAsync(name);
            foreach (var item in items)
            {
                if (item.CategoryId == category.Id)
                {
                    products.Add(item);
                }
            }

            return products;
        }
        public async Task<List<ProductViewModel>> GetProductByTag(string name)
        {
            var products = new List<ProductViewModel>();
			var tags = await _tagRepository.GetAsync(x => x.Name == name);
			var items = await _productTagRepository.GetAllAsync(x => x.Tag == tags);

			foreach(var item in items)
			{
				var product = await _repository.GetAsync(x => x.Id == item.ProductId);
				products.Add(product);
			}

            return products;
        }
		public async Task<List<ProductViewModel>> GetProductByCategoryAndTag(string name, string categoryName)
		{
			var products = new List<ProductViewModel>();
			var tags = await _tagRepository.GetAsync(x => x.Name == name);
			var items = await _productTagRepository.GetAllAsync(x => x.Tag == tags);
			var category = await _categoryService.GetAsync(categoryName);
			foreach (var item in items)
			{
				var product = await _repository.GetAsync(x => x.Id == item.ProductId);
				if(product.CategoryId == category.Id)
				{
					products.Add(product);
				}
			}

			return products;
		}
		public async Task AddProductTagsAsync(ProductEntity entity, string[] tags)
		{
			var product = await _repository.GetAsync(x => x.Name == entity.Name);
			foreach(var tag in tags)
			{
				await _productTagRepository.CreateAsync(new ProductTagEntity
				{
					ProductId = product.Id,
					TagId = int.Parse(tag)
				});
			}
		} 
        public async Task<List<ProductViewModel>> DiscoverProductsAsync()
        {
            var products = new List<ProductViewModel>();
			var random = new Random();
			string categoryName = "";
			int category = 0;
			var categories = await _categoryService.GetAllCategoriesAsync();
			var items = new List<ProductEntity>();
			do
			{
				category = random.Next(categories.Count);
				categoryName = await _categoryService.GetCategoryName(category);
				items = await _repository.GetProductsDescending(category);

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
					CategoryName = categoryName

				};
                    products.Add(productModel);
            }
            return products;
        }

        public async Task<ProductViewModel> ShowCaseProduct()
		{
			var random = new Random();
			var tagProductList = await _productTagRepository.GetAllAsync(x => x.TagId == 2);
			var productList = new List<ProductTagEntity>();
			foreach(var tag  in tagProductList)
			{
				productList.Add(tag);
			}
			var index = random.Next(productList.Count);
			var product = await _repository.GetAsync(x => x.Id == productList[index].ProductId);
			return product;
		} 

		public async Task<bool> RemoveProductAsync(ProductViewModel model)
		{
			var product = await _repository.DeleteAsync(x => x.Id == model.Id);
			if (product)
			{
				return true;
			}
			else
			{
				return false;
			}

		}
		public List<ProductViewModel> GetCookies()
		{
			var cookie = _httpContextAccessor.HttpContext!.Request.Cookies["VisitedProducts"];
			var productlist = new List<ProductViewModel>();
			
			if (cookie != null)
			{
				var json = JsonSerializer.Deserialize<List<ProductViewModel>>(cookie);
				foreach (var item in json!)
				{

					productlist.Add(item);
					
				}
			}


			return productlist;
		} 
	}
}
