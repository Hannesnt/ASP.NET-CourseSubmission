using ASP.NET_Course_Submission.Models.Context;
using ASP.NET_Course_Submission.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace ASP.NET_Course_Submission.Helpers.Repositories.IdentityRepos
{
    public class ProfileAddressRepository : IdentityRepository<ProfileAddressEntity>
    {
       
		public ProfileAddressRepository(IdentityContext context) : base(context)
		{
			
		}

    }
}
