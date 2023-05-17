using ASP.NET_Course_Submission.Models.Context;
using ASP.NET_Course_Submission.Models.Entities;

namespace ASP.NET_Course_Submission.Helpers.Repositories.ContextRepos
{
	public class TagRepository : DataRepository<TagEntity>
	{
		public TagRepository(DataContext context) : base(context)
		{
		}
	}
}
