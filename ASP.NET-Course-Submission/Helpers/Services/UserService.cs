using ASP.NET_Course_Submission.Models.Context;
using ASP.NET_Course_Submission.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace ASP.NET_Course_Submission.Helpers.Services
{
    public class UserService
    {
        private readonly IdentityContext _identityContext;

        public UserService(IdentityContext identityContext)
        {
            _identityContext = identityContext;
        }
        public async Task<ProfileEntity> GetUserProfileAsync(string userId)
        {
            var userProfileEntity = await _identityContext.Profiles.FirstOrDefaultAsync(x => x.Id == userId);
            return userProfileEntity!;
        }
    }
}
