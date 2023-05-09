using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace ASP.NET_Course_Submission.Models.Interfaces
{
    public interface IProduct
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }

        public string ProductImage { get; set; }
		public int CategoryId { get; set; }

		public bool New { get; set; }

		public bool Featured { get; set; }

		public bool Popular { get; set; }
	}
}
