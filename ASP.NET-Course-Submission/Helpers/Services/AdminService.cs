using ASP.NET_Course_Submission.Helpers.Repositories.IdentityRepos;
using ASP.NET_Course_Submission.Models.Context;
using ASP.NET_Course_Submission.Models.Entities;
using ASP.NET_Course_Submission.Models.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace ASP.NET_Course_Submission.Helpers.Services
{
	public class AdminService
	{
		private readonly IdentityContext _identityContext;
		private readonly AddressRepository _addressRepository;
		private readonly UserManager<IdentityUser> _userManager;

		public AdminService(UserManager<IdentityUser> userManager, AddressRepository addressRepository,  IdentityContext identityContext)
		{
			_userManager = userManager;
			_addressRepository = addressRepository;
			_identityContext = identityContext;
		}

		public async Task<bool> AdminRegisterAsync(AdminRegUserViewModel model)
		{
			try
			{
				IdentityUser identityUser = model;
				await _userManager.CreateAsync(identityUser, model.Password);

				await _userManager.AddToRoleAsync(identityUser, model.Role);

				ProfileEntity profileEntity = model;
				profileEntity.Id = identityUser.Id;

				_identityContext.Add(profileEntity);

				var address = await _addressRepository.GetAsync(x => x.StreetName == model.StreetName && x.City == model.City && x.PostalCode == model.PostalCode);

				if (address != null)
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
		public async Task<bool> AdminChangeRole(ProfileViewModel model)
		{
			var user = await _userManager.FindByIdAsync(model.Id!);

			
			if (user != null)
			{
				var role = await _userManager.GetRolesAsync(user);

				foreach(var roleEntity in role)
				{
					await _userManager.RemoveFromRoleAsync(user, roleEntity);
				}
				await _userManager.AddToRoleAsync(user, model.RoleName);
				await _userManager.UpdateAsync(user);
				return true;
			}
			else
			{
				return false;
			}
		
		} 
	}
}
