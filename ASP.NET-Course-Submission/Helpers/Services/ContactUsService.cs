using ASP.NET_Course_Submission.Helpers.Repositories.ContextRepos;
using ASP.NET_Course_Submission.Models.Context;
using ASP.NET_Course_Submission.Models.Entities;
using ASP.NET_Course_Submission.Models.ViewModels;

namespace ASP.NET_Course_Submission.Helpers.Services
{
    public class ContactUsService
    {
        private readonly DataContext _context;
        private readonly ContactUserRepository _contactUserRepository;
        private readonly ContactMessageRepository _contactMessageRepository;



        public ContactUsService(ContactUserRepository contactUserRepository, DataContext context, ContactMessageRepository contactMessageRepository)
        {
            _contactUserRepository = contactUserRepository;
            _context = context;
            _contactMessageRepository = contactMessageRepository;
        }

        public async Task<bool> RegisterContactUser(ContactUsViewModel model)
        {
            try
            {
                ContactUserEntity contactUserEntity = model;
                ContactMessageEntity contactMessageEntity = model;

                var user = await _contactUserRepository.GetAsync(x => x.Email == model.Email);
                if (user != null) 
                { 
                    contactMessageEntity.Id = user.Id;
                    await _contactMessageRepository.CreateAsync(contactMessageEntity);

                }
                else
                {
                    await _contactUserRepository.CreateAsync(contactUserEntity);

                    contactMessageEntity.ContactUserId = contactUserEntity.Id;

                    await _contactMessageRepository.CreateAsync(contactMessageEntity);

                }
                
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
