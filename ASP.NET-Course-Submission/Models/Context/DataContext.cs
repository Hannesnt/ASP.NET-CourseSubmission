
using Microsoft.EntityFrameworkCore;

namespace ASP.NET_Course_Submission.Models.Context
{
	public class DataContext : DbContext
	{
		public DataContext(DbContextOptions<DataContext> options) : base(options)
		{

		}
	}
}
