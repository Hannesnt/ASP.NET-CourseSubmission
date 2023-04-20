using System.ComponentModel.DataAnnotations;
using ASP.NET_Course_Submission.Models.Entities;
using Microsoft.AspNetCore.Identity;

namespace ASP.NET_Course_Submission.Models.ViewModels
{
	public class RegisterViewModel
	{
		[Required(ErrorMessage = "Du måste ange ett förnamn")]
		[RegularExpression(@"^[a-öA-Ö]+(?:[ é'-][a-öA-Ö]+)*$", ErrorMessage = "Du måste ange ett giltig förnamn")]
		[Display(Name = "Förnamn*")]
		public string FirstName { get; set; } = null!;

		[Required(ErrorMessage = "Du måste ange ett efternamn")]
		[Display(Name = "Efternamn*")]
		public string LastName { get; set; } = null!;

		[Required(ErrorMessage = "Du måste ange en e-postadress")]
		[RegularExpression(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$", ErrorMessage = "Du måste ange ett giltig e-postadress")]
		[Display(Name = "E-postadress*")]
		[DataType(DataType.EmailAddress)]
		public string Email { get; set; } = null!;

		[Required(ErrorMessage = "Du måste ange ett lösenord")]
		[RegularExpression(@"^(?=.*[A-Za-z])(?=.*\d)(?=.*[@$!%*#?&])[A-Za-z\d@$!%*#?&]{8,}$", ErrorMessage = "Du måste ange ett giltigt lösenord, minst 8 tecken varav 1 bokstav, 1 nummer och 1 specialtecken")]
		[Display(Name = "Lösenord*")]
		[DataType(DataType.Password)]
		public string Password { get; set; } = null!;

		[Required(ErrorMessage = "Du måste bekräfta ditt lösenord")]
		[Compare(nameof(Password), ErrorMessage = "Lösenorden matchar inte")]
		[Display(Name = "Bekräfta lösenord*")]
		[DataType(DataType.Password)]
		public string ConfirmPassword { get; set; } = null!;

		[Required(ErrorMessage = "Du måste ange gatunamn")]
		[Display(Name = "Gatunamn*")]
		public string StreetName { get; set; } = null!;

		[Required(ErrorMessage = "Du måste ange ditt postnummer")]
		[Display(Name = "Postnummer*")]
		public string PostalCode { get; set; } = null!;

		[Required(ErrorMessage = "Du måste ange din stad")]
		[Display(Name = "Stad*")]
		public string City { get; set; } = null!;

		[Display(Name = "Telefon (Valfritt)")]
		public string? Phone { get; set; }
		[Display(Name = "Företag (Valfritt)")]
		public string? Company { get; set; }
		[Display(Name = "Profilbild (Valfritt)")]
		public string? ProfileImage { get; set; }

		public static implicit operator ProfileEntity(RegisterViewModel registerViewModel)
		{
			return new ProfileEntity
			{
				FirstName = registerViewModel.FirstName,
				LastName = registerViewModel.LastName,
				ProfileImage = registerViewModel.ProfileImage,
				PhoneNumber = registerViewModel.Phone,
				CompanyName = registerViewModel.Company,
			};
		} 
		public static implicit operator AddressEntity(RegisterViewModel registerViewModel)
		{
			return new AddressEntity
			{
				StreetName = registerViewModel.StreetName,
				PostalCode = registerViewModel.PostalCode,
				City = registerViewModel.City,
			};
		}
		public static implicit operator IdentityUser(RegisterViewModel registerViewModel)
		{
			return new IdentityUser
			{
				UserName = registerViewModel.Email,
				PhoneNumber = registerViewModel.Phone,
				Email = registerViewModel.Email,
			};
		}
	}
}
