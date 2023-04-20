using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace ASP.NET_Course_Submission.Models.Interfaces
{
    public interface IProduct
    {
        public string Name { get; set; }
        public string? Description { get; set; }
        public decimal Price { get; set; }

        public IFormFile ProductImage { get; set; }
    }
}
