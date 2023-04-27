using ASP.NET_Course_Submission.Models.Context;

namespace ASP.NET_Course_Submission.Helpers.Repositories.IdentityRepos
{
	public class AdminRepository : IdentityRepository<AdminRepository>
	{
		public AdminRepository(IdentityContext context) : base(context)
		{
		}
	}
}
