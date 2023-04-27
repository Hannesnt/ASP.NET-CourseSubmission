using System.ComponentModel.DataAnnotations;
using ASP.NET_Course_Submission.Models.Entities;
using ASP.NET_Course_Submission.Models.Interfaces;

namespace ASP.NET_Course_Submission.Models.ViewModels
{
    public class ProfileViewModel : IProfile, ICompany
    {
        public string? Id { get; set; }
        public string? FirstName { get; set; } 
        public string? LastName { get; set; } 
        public string? PhoneNumber { get; set; } 
        public string? ProfileImage { get; set; }
        public string? CompanyName { get; set; }

        [Display(Name = "Change role")]
        [Required(ErrorMessage = "You need to provide a role")]
        public string RoleName { get; set; } = null!;

		public static implicit operator ProfileEntity(ProfileViewModel registerViewModel)
        {
            return new ProfileEntity
            {
                FirstName = registerViewModel.FirstName!,
                LastName = registerViewModel.LastName!,
                PhoneNumber = registerViewModel.PhoneNumber,
                ProfileImage = registerViewModel.ProfileImage,
                CompanyName = registerViewModel.CompanyName,
            };
        }
	}
}
