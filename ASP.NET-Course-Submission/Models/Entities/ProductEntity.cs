using System.ComponentModel.DataAnnotations.Schema;
using ASP.NET_Course_Submission.Models.Interfaces;
using ASP.NET_Course_Submission.Models.ViewModels;

namespace ASP.NET_Course_Submission.Models.Entities
{
    public class ProductEntity : IProduct
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        [Column(TypeName = "money")]
        public decimal Price { get; set; }
        public string ProductImage { get; set; } = null!;

        public int CategoryId { get; set; }

        public CategoryEntity Category { get; set; } = null!;

        public int Discount { get; set; }

        public ICollection<ProductTagEntity> ProductTags { get; set; } = new HashSet<ProductTagEntity>();

        public static implicit operator ProductViewModel(ProductEntity entity)
		{
			return new ProductViewModel
			{
                Id = entity.Id,
                Name = entity.Name,
                Price = entity.Price,
                Description = entity.Description!,
                ProductImage = entity.ProductImage,
                CategoryId = entity.CategoryId,
                Discount = entity.Discount
			};
		}
	}
}
