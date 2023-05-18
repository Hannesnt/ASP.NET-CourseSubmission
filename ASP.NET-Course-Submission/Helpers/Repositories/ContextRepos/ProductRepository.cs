using ASP.NET_Course_Submission.Models.Context;
using ASP.NET_Course_Submission.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace ASP.NET_Course_Submission.Helpers.Repositories.ContextRepos
{
	public class ProductRepository : DataRepository<ProductEntity>
	{
		public ProductRepository(DataContext context) : base(context)
		{

		}
		public async Task<List<ProductEntity>> GetProductsDescending(int category)
		{
			var items = await _context.Products.OrderByDescending(p => p.Id).Include(x => x.Category).Where(x => x.Category.Id == category).ToListAsync();
			return items;
		}
	}
}
