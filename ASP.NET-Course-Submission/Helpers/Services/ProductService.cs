using ASP.NET_Course_Submission.Helpers.Repositories.ContextRepos;
using ASP.NET_Course_Submission.Models.Context;
using ASP.NET_Course_Submission.Models.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace ASP.NET_Course_Submission.Helpers.Services
{
	public class ProductService
	{
		private readonly DataContext _context;
		private readonly ProductRepository _repository;
		public ProductService(DataContext context, ProductRepository repository)
		{
			_context = context;
			_repository = repository;
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
	}
}
