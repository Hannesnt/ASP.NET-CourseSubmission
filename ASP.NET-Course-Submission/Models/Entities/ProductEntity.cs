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

        public bool New { get; set; }

        public bool Featured { get; set; }

        public bool Popular { get; set; }
        public bool OnSale { get; set; }

        public int Discount { get; set; }

        public static implicit operator ProductViewModel(ProductEntity entity)
		{
			return new ProductViewModel
			{
                Id = entity.Id,
                Name = entity.Name,
                Price = entity.Price,
                ProductImage = entity.ProductImage,
                CategoryId = entity.CategoryId,
                New = entity.New,
                Featured = entity.Featured,
                Popular = entity.Popular,
                OnSale = entity.OnSale,
                Discount = entity.Discount
			};
		}
	}
}
