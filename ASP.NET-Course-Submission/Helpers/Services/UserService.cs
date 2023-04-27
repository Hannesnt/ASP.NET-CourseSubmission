using ASP.NET_Course_Submission.Helpers.Repositories.ContextRepos;
using ASP.NET_Course_Submission.Helpers.Repositories.IdentityRepos;
using ASP.NET_Course_Submission.Models.Context;
using ASP.NET_Course_Submission.Models.Entities;
using ASP.NET_Course_Submission.Models.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;

namespace ASP.NET_Course_Submission.Helpers.Services
{
    public class UserService
    {
        private readonly IdentityContext _identityContext;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly ProfileRepository _profileRepository;
        public UserService(IdentityContext identityContext, UserManager<IdentityUser> userManager, ProfileRepository profileRepository)
        {
            _identityContext = identityContext;
            _userManager = userManager;
            _profileRepository = profileRepository;
        }
        public async Task<IEnumerable<ProfileViewModel>> GetUserAsync()
        {
            var UserRoles = new List <ProfileViewModel>();

            var Users = await _userManager.Users.ToListAsync();

            foreach(var user in Users)
            {
                List<string> roles = (List<string>)await _userManager.GetRolesAsync(user);

                var userProfile = await _profileRepository.GetAsync(x => x.Id == user.Id);

                var userWithRole = new ProfileViewModel
                {
                    Id = userProfile.Id,
                    FirstName = userProfile.FirstName,
                    LastName = userProfile.LastName,
                    PhoneNumber = userProfile.PhoneNumber,
                    ProfileImage = userProfile.ProfileImage,
                    CompanyName = userProfile.CompanyName,
                    RoleName = roles[0],
                };
                UserRoles.Add(userWithRole);
            }

            return UserRoles;

        }
		public async Task<IEnumerable<RoleViewModel>> GetRolesAsync()
		{
			var roles = new List<RoleViewModel>();
			var items = await _identityContext.Roles.ToListAsync();
			foreach (var role in items)
			{
				roles.Add(new RoleViewModel
				{
					Id = role.Id,
					Name = role.Name!
				});
			}
			return roles;
		}
	}
}
