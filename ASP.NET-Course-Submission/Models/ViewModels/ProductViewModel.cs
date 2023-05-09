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

		public int Discount { get; set; }
		public int CategoryId { get; set; }
		public string? CategoryName { get; set; }
		public string ProductImage { get; set; } = null!;
		public bool New { get; set; }
		public bool Featured { get; set; }
		public bool Popular { get; set; }

		public bool OnSale { get; set; }

		public static implicit operator RegisterProductViewModel(ProductViewModel model)
		{
			return new RegisterProductViewModel
			{
				Name = model.Name,
				Description = model.Description!,
				Price = model.Price,
				Discount = model.Discount,
				CategoryId = model.CategoryId,
				ProductImage = model.ProductImage,
				New = model.New,
				Featured = model.Featured,
				Popular = model.Popular,
				OnSale = model.OnSale,
			};
		}
		public static implicit operator ProductEntity(ProductViewModel model)
		{
			return new ProductEntity
			{
				Id = model.Id,
				Name = model.Name,
				Description = model.Description,
				Price = model.Price,
				Discount = model.Discount,
				CategoryId = model.CategoryId,
				ProductImage = model.ProductImage,
				New = model.New,
				Featured = model.Featured,
				Popular = model.Popular,
				OnSale = model.OnSale,

			};
		}
	}
}
