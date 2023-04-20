namespace ASP.NET_Course_Submission.Models.Interfaces
{
    public interface IUserContact
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string? PhoneNumber { get; set; }
        public string Email { get; set; }
    }
}
