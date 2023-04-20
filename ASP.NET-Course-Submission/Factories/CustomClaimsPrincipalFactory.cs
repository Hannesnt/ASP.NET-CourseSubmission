using ASP.NET_Course_Submission.Helpers.Repositories.IdentityRepos;
using ASP.NET_Course_Submission.Helpers.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using System.Security.Claims;

namespace WebApp.Factories
{
    public class CustomClaimsPrincipalFactory : UserClaimsPrincipalFactory<IdentityUser>
    {
        private readonly ProfileRepository profileRepository;

        public CustomClaimsPrincipalFactory(UserManager<IdentityUser> userManager, IOptions<IdentityOptions> optionsAccessor, ProfileRepository profileRepository) : base(userManager, optionsAccessor)
        {
            this.profileRepository = profileRepository;
        }

        protected override async Task<ClaimsIdentity> GenerateClaimsAsync(IdentityUser user)
        {
            var claimsIdentity = await base.GenerateClaimsAsync(user);

            var userProfileEntity = await profileRepository.GetAsync(x => x.Id == user.Id);

            claimsIdentity.AddClaim(new Claim("DisplayName", $"{userProfileEntity.FirstName}"));

            var roles = await UserManager.GetRolesAsync(user);
            claimsIdentity.AddClaims(roles.Select(x => new Claim(ClaimTypes.Role, x)));

            return claimsIdentity;
        }
    }
}
