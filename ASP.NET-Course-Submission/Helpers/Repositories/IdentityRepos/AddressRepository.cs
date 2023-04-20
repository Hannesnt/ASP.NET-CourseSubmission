using ASP.NET_Course_Submission.Models.Context;
using ASP.NET_Course_Submission.Models.Entities;
using ASP.NET_Course_Submission.Models.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace ASP.NET_Course_Submission.Helpers.Repositories.IdentityRepos
{
	public class AddressRepository : IdentityRepository<AddressEntity>
	{
		private readonly IdentityContext _identityContext;
		public AddressRepository(IdentityContext context, IdentityContext identityContext) : base(context)
		{
			_identityContext = identityContext;
		}
	}
}
