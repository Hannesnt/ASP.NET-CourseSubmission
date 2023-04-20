using ASP.NET_Course_Submission.Models.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ASP.NET_Course_Submission.Models.Context
{
	public class IdentityContext : IdentityDbContext
	{
		public IdentityContext(DbContextOptions<IdentityContext> options) : base(options)
		{
		}
		public DbSet<ProfileEntity> Profiles { get; set; }
		public DbSet<AddressEntity> Address { get; set; }
		public DbSet<ProfileAddressEntity> ProfileAddresses { get; set; }
	}
}
