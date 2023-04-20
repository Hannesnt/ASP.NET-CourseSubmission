using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ASP.NET_Course_Submission.Models.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace ASP.NET_Course_Submission.Models.Entities
{
	public class ProfileEntity : IProfile, ICompany
	{
		[Key, ForeignKey(nameof(User))]
		public string Id { get; set; } = null!;
		public string FirstName { get; set; } = null!;
		public string LastName { get; set; } = null!;
		public string? ProfileImage { get; set; }
		public string? PhoneNumber { get; set; }
		public string? CompanyName { get; set; }

		public IdentityUser User { get; set; } = null!;

		public ICollection<ProfileAddressEntity> Addresses { get; set; } = new HashSet<ProfileAddressEntity>();



	}
}
