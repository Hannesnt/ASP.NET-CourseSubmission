using ASP.NET_Course_Submission.Models.Interfaces;

namespace ASP.NET_Course_Submission.Models.ViewModels
{
    public class CurrentUserViewModel : IProfile
    {
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;

        public string Email { get; set; } = null!;
        public string? PhoneNumber { get; set; }
        public string? ProfileImage { get; set; }

        public string? CompanyName { get; set; }

        public List<AddressViewModel> Address { get; set; } = null!;

    }
}
