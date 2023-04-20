using ASP.NET_Course_Submission.Models.Context;
using ASP.NET_Course_Submission.Models.Entities;

namespace ASP.NET_Course_Submission.Helpers.Repositories.IdentityRepos
{
	public class ProfileRepository : IdentityRepository<ProfileEntity>
	{
		public ProfileRepository(IdentityContext context) : base(context)
		{
		}


	}
}
