using ASP.NET_Course_Submission.Models.Entities;
using ASP.NET_Course_Submission.Models.Interfaces;

namespace ASP.NET_Course_Submission.Models.ViewModels
{
	public class ProductViewModel : IProduct
	{
		public int Id { get; set; }
		public string Name { get; set; } = null!;
		public string Description { get; set; } = null!;
		public decimal Price { get; set; }

		public int CategoryId { get; set; }
		public string ProductImage { get; set; } = null!;
		public bool New { get; set; }
		public bool Featured { get; set; }
		public bool Popular { get; set; }

	}
}
