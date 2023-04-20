using ASP.NET_Course_Submission.Models.Interfaces;

namespace ASP.NET_Course_Submission.Models.Entities
{
    public class ProductEntity : IProduct
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public IFormFile ProductImage { get; set; } = null!;

        public int CategoryId { get; set; }

        public CategoryEntity Category { get; set; } = null!;

        public bool New { get; set; }

        public bool Featured { get; set; }

        public bool Popular { get; set; }
    }
}
