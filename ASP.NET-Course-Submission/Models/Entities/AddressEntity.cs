using ASP.NET_Course_Submission.Models.Interfaces;

namespace ASP.NET_Course_Submission.Models.Entities
{
	public class AddressEntity : IAddress
	{
		public int Id { get; set; }	
		public string StreetName { get; set; } = null!;
		public string PostalCode { get; set; } = null!;
		public string City { get; set; } = null!;

		public ICollection<ProfileAddressEntity> Profiles { get; set; } = new HashSet<ProfileAddressEntity>();
	}
}
