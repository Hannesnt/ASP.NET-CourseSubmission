using System.ComponentModel.DataAnnotations;
using ASP.NET_Course_Submission.Models.Interfaces;

namespace ASP.NET_Course_Submission.Models.ViewModels
{
	public class LoginViewModel : ILoginInformation
	{
		[Required(ErrorMessage = "Du måste ange ett e-postadress")]
		[Display(Name = "E-postadress")]
		[DataType(DataType.EmailAddress)]
		public string Email { get; set; } = null!;


		[Required(ErrorMessage = "Du måste ange ett lösenord")]
		[Display(Name = "Lösenord")]
		[DataType(DataType.Password)]
		public string Password { get; set; } = null!;

		public bool RememberMe { get; set; }
	}
}
