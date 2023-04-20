using ASP.NET_Course_Submission.Models.Context;
using ASP.NET_Course_Submission.Models.Entities;

namespace ASP.NET_Course_Submission.Helpers.Repositories.ContextRepos
{
    public class ContactMessageRepository : DataRepository<ContactMessageEntity>
    {
        public ContactMessageRepository(DataContext context) : base(context)
        {
        }
    }
}
