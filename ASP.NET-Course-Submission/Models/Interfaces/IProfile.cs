namespace ASP.NET_Course_Submission.Models.Interfaces
{
	public interface IProfile
	{
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string? PhoneNumber { get; set; }
		public string? ProfileImage { get; set; }
	}
}
