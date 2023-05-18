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

		public async Task<List<CategoryViewModel>> GetAllCategoriesAsync()
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
		public async Task<CategoryViewModel> GetAsync(int id)
		{
			var item = await _context.Categories.FirstOrDefaultAsync(x => x.Id == id);
			return item!;

        }
		public async Task<CategoryViewModel> GetAsync(string name)
		{
			var item = await _context.Categories.FirstOrDefaultAsync(x => x.CategoryName == name);
			return item!;

		}

		public async Task<string> GetCategoryName(int id)
		{
			var name = "";
			var item = await _context.Categories.FirstOrDefaultAsync(x => x.Id == id);
			name = item?.CategoryName;
			return name!;

		}
	}
}
