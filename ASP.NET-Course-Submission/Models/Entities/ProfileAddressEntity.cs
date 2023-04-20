using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ASP.NET_Course_Submission.Models.Entities
{
	[PrimaryKey(nameof(ProfileId), nameof(AddressId))]
	public class ProfileAddressEntity
	{
		[Key, ForeignKey(nameof(Profile))]
		public string ProfileId { get; set; } = null!;

		public ProfileEntity Profile { get; set; } = null!;

		[Key, ForeignKey(nameof(Address))]
		public int AddressId { get; set; }

		public AddressEntity Address { get; set; } = null!;
	}
}
