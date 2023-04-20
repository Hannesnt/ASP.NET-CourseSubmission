using ASP.NET_Course_Submission.Models.Interfaces;

namespace ASP.NET_Course_Submission.Models.Entities
{
    public class ContactMessageEntity : IContactMessage
    {
        public int Id { get; set; }

        public string Description { get; set; } = null!;

        public int ContactUserId { get; set; }
        public ContactUserEntity ContactUser { get; set; } = null!;

        public DateTime Created { get; set; } = DateTime.Now;

    }
}
