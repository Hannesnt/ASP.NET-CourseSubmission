using System.Security.Claims;
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
        private readonly AddressRepository _addressRepository;
        private readonly ProfileAddressRepository _profileAddressRepository;
        public UserService(IdentityContext identityContext, UserManager<IdentityUser> userManager, ProfileRepository profileRepository, AddressRepository addressRepository, ProfileAddressRepository profileAddressRepository)
        {
            _identityContext = identityContext;
            _userManager = userManager;
            _profileRepository = profileRepository;
            _addressRepository = addressRepository;
            _profileAddressRepository = profileAddressRepository;
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
        public async Task<CurrentUserViewModel> CurrentUser(ClaimsPrincipal user)
        {
            try
            {
                
                var signedinUser = await _userManager.FindByEmailAsync(user.Identity!.Name!);
                var profile = await _profileRepository.GetAsync(x => x.Id == signedinUser!.Id);
                var profileAddress = await _profileAddressRepository.GetAllAsync(x => x.ProfileId == profile.Id);
                
                var addresses = new List<AddressViewModel>();
                foreach (var address in profileAddress)
                {
                    var Adress = await _addressRepository.GetAsync(x => x.Id == address.AddressId);
                    addresses.Add(new AddressViewModel
                    {
                        StreetName = Adress.StreetName,
                        City = Adress.City,
                        PostalCode = Adress.PostalCode,
                    });
                }
                var currentUser = new CurrentUserViewModel
                {
                    FirstName = profile.FirstName,
                    LastName = profile.LastName,
                    Email = signedinUser!.UserName!,
                    PhoneNumber = profile.PhoneNumber,
                    ProfileImage = profile.ProfileImage,
                    CompanyName = profile.CompanyName,
                    Address = addresses,

                };
                return currentUser;
            }
            catch
            {
                return null!;
            }
        }

	}
}
