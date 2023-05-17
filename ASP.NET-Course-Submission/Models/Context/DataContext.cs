
using ASP.NET_Course_Submission.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace ASP.NET_Course_Submission.Models.Context
{
	public class DataContext : DbContext
	{
		public DataContext(DbContextOptions<DataContext> options) : base(options)
		{

		}
		public DbSet<ContactUserEntity> ContactUser { get; set; }
		public DbSet<ContactMessageEntity> ContactMessage { get; set; }
		public DbSet<ProductEntity> Products { get; set; }
		public DbSet<CategoryEntity> Categories { get; set; }
		public DbSet<TagEntity> Tags { get; set; }
		public DbSet<ProductTagEntity> ProductTags { get; set; }
	}
}
