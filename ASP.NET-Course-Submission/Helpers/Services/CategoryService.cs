using ASP.NET_Course_Submission.Models.Context;
using ASP.NET_Course_Submission.Models.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace ASP.NET_Course_Submission.Helpers.Services
{
	public class CategoryService
	{
		private readonly DataContext _context;

		public CategoryService(DataContext context)
		{
			_context = context;
		}

		public async Task<IEnumerable<CategoryViewModel>> GetAllCategoriesAsync()
		{
			var categories = new List<CategoryViewModel>();
			var items = await _context.Categories.ToListAsync();
			foreach (var item in items)
			{
				categories.Add(new CategoryViewModel
				{
					Id = item.Id,
					CategoryName = item.CategoryName
				});
			}
			return categories;
		}
	}
}
