using ASP.NET_Course_Submission.Models.Context;
using ASP.NET_Course_Submission.Models.Entities;

namespace ASP.NET_Course_Submission.Helpers.Repositories.ContextRepos
{
	public class ProductRepository : DataRepository<ProductEntity>
	{
		public ProductRepository(DataContext context) : base(context)
		{
		}
	}
}
