using ASP.NET_Course_Submission.Models.Interfaces;

namespace ASP.NET_Course_Submission.Models.ViewModels
{
	public class AccountRegisterViewModel : IProfileRegistration
	{
		public string FirstName { get; set; } = null!;
		public string LastName { get; set; } = null!;
		public string ProfileImage { get; set; } = null!;
		public string Email { get; set; } = null!;
		public string? PhoneNumber { get; set; }
		public string? CompanyName { get; set; }
		public string StreetName { get; set; } = null!;
		public string PostalCode { get; set; } = null!;
		public string City { get; set; } = null!;
		public string Country { get; set; } = null!;
		public string Password { get; set; } = null!;

		public string ConfirmPassword { get; set; } = null!;
	}
}
