using ASP.NET_Course_Submission.Models.Interfaces;

namespace ASP.NET_Course_Submission.Models.Entities
{
    public class ContactUserEntity : IUserContact
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string? PhoneNumber { get; set; }
        public string Email { get; set; } = null!;

        public ICollection<ContactMessageEntity> ContactMessage = new HashSet<ContactMessageEntity>();
    }
}
