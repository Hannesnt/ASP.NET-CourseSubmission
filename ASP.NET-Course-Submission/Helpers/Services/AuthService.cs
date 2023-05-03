using System.Linq.Expressions;
using System.Security.Claims;
using ASP.NET_Course_Submission.Helpers.Repositories.IdentityRepos;
using ASP.NET_Course_Submission.Models.Context;
using ASP.NET_Course_Submission.Models.Entities;
using ASP.NET_Course_Submission.Models.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace ASP.NET_Course_Submission.Helpers.Services
{
	public class AuthService
	{
		private readonly IdentityContext _identityContext;
		private readonly ProfileRepository _profileRepository;
		private readonly AddressRepository _addressRepository;
		private readonly UserManager<IdentityUser> _userManager;
		private readonly SignInManager<IdentityUser> _signInManager;
        private readonly SeedService _seedService;
		private readonly RoleManager<IdentityRole> _roleManager;
		public AuthService(AddressRepository addressRepository, ProfileRepository profileRepository, IdentityContext identityContext, UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager, SeedService seedService, RoleManager<IdentityRole> roleManager)
		{
			_addressRepository = addressRepository;
			_profileRepository = profileRepository;
			_identityContext = identityContext;
			_userManager = userManager;
			_signInManager = signInManager;
			_seedService = seedService;
			_roleManager = roleManager;
		}


		public async Task<bool> RegisterAsync(RegisterViewModel model)
		{
			try
			{
                await _seedService.SeedRoles();
                var roleName = "user";

                if (!await _userManager.Users.AnyAsync())
                    roleName = "admin";

                IdentityUser identityUser = model;
				await _userManager.CreateAsync(identityUser, model.Password);
                await _userManager.AddToRoleAsync(identityUser, roleName);
                ProfileEntity profileEntity = model;
				profileEntity.Id = identityUser.Id;
				_identityContext.Add(profileEntity);

				var address = await _addressRepository.GetAsync(x => x.StreetName == model.StreetName && x.City == model.City && x.PostalCode == model.PostalCode);

				if(address != null)
				{
					_identityContext.ProfileAddresses.Add(new ProfileAddressEntity
					{
						AddressId = address.Id,
						ProfileId = profileEntity.Id,
					});
					await _identityContext.SaveChangesAsync();
				}
				else
				{

					AddressEntity addressEntity = model;
					await _addressRepository.CreateAsync(addressEntity);

					_identityContext.ProfileAddresses.Add(new ProfileAddressEntity
					{
						AddressId = addressEntity.Id,
						ProfileId = profileEntity.Id,
					});
					await _identityContext.SaveChangesAsync();
				}
				return true;
			}
			catch
			{
				return false;
			}

		}
		public async Task<bool> SignInAsync(LoginViewModel model)
		{
			try
			{
				var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, false);

				return result.Succeeded;
			}
			catch
			{
				return false;
			}
		}
		public async Task<bool> UserAlreadyExistsAsync(Expression<Func<IdentityUser, bool>> expression)
		{
			return await _userManager.Users.AnyAsync(expression);
		}
        public async Task<bool> SignOutAsync(ClaimsPrincipal user)
        {
            await _signInManager.SignOutAsync();
            return _signInManager.IsSignedIn(user);


        }

    }
}
