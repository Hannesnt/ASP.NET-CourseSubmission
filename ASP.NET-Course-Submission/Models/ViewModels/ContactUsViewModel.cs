using System.ComponentModel.DataAnnotations;
using ASP.NET_Course_Submission.Models.Entities;
using ASP.NET_Course_Submission.Models.Interfaces;

namespace ASP.NET_Course_Submission.Models.ViewModels
{
	public class ContactUsViewModel : IUserContact, IContactMessage
	{

		[Required(ErrorMessage = "Du måste ange ett förnamn")]
		[RegularExpression(@"^[a-öA-Ö]+(?:[ é'-][a-öA-Ö]+)*$", ErrorMessage = "Du måste ange ett giltig förnamn")]
		[Display(Name = "Förnamn*")]
		public string FirstName { get; set; } = null!;



		[Required(ErrorMessage = "Du måste ange ett efternamn")]
		[Display(Name = "Efternamn*")]
		public string LastName { get; set; } = null!;


		[Display(Name = "Telefon (Valfritt)")]
		public string? PhoneNumber { get; set; }


		[Required(ErrorMessage = "Du måste ange en e-postadress")]
		[RegularExpression(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$", ErrorMessage = "Du måste ange ett giltig e-postadress")]
		[Display(Name = "E-postadress*")]
		[DataType(DataType.EmailAddress)]
		public string Email { get; set; } = null!;


		[Required(ErrorMessage = "Du måste ange ett meddelande")]
		[Display(Name = "Beskrivning*")]
		public string Description { get; set; } = null!;

		public static implicit operator ContactUserEntity(ContactUsViewModel model)
		{
			return new ContactUserEntity
			{
				FirstName = model.FirstName,
				LastName = model.LastName,
				PhoneNumber = model.PhoneNumber,
				Email = model.Email,
			};
		}
		public static implicit operator ContactMessageEntity(ContactUsViewModel model)
		{
			return new ContactMessageEntity
			{
				Description = model.Description
			};
		}
	}
}
