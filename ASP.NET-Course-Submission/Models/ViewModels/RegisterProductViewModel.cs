using System.ComponentModel.DataAnnotations;
using ASP.NET_Course_Submission.Models.Entities;
using ASP.NET_Course_Submission.Models.Interfaces;

namespace ASP.NET_Course_Submission.Models.ViewModels
{
	public class RegisterProductViewModel : IProduct
	{
		[Required(ErrorMessage = "Du måste ange ett produktnamn")]
		[Display(Name = "Produktnamn *")]
		public string Name { get; set; } = null!;

		[Display(Name = "Produkt Beskrivning (valfritt)")]
		public string? Description { get; set; }


		[Required(ErrorMessage = "Du måste ange ett produktpris")]
		[Display(Name = "Produktpris*")]
		[DataType(DataType.Currency)]
		public decimal Price { get; set; }

		[Required(ErrorMessage = "Du måste ange en produktbild")]
		[Display(Name = "Produktbild *")]
		public string ProductImage { get; set; } = null!;

		[Required(ErrorMessage = "Du måste välja en kategori")]
		[Display(Name = "Kategori *")]
		public int CategoryId { get; set; }


        [Required(ErrorMessage = "Du måste välja procentuell rabbat 0-100. ")]
        [RegularExpression(@"^(?:100|\d{1,2})$", ErrorMessage = "Ingen giltig rabatt")]
        [Display(Name = "Procentuell rabatt * (0-100)")]
        public int Discount { get; set; }


        public static implicit operator ProductEntity(RegisterProductViewModel RegisterProductViewModel)
		{
			return new ProductEntity
			{
				Name = RegisterProductViewModel.Name,
				Description = RegisterProductViewModel.Description,
				Price = RegisterProductViewModel.Price,
				ProductImage = RegisterProductViewModel.ProductImage,
				CategoryId = RegisterProductViewModel.CategoryId,
				Discount = RegisterProductViewModel.Discount,
			};
		}
		public static implicit operator ProductViewModel(RegisterProductViewModel RegisterProductViewModel)
		{
			return new ProductViewModel
			{
				Name = RegisterProductViewModel.Name,
				Description = RegisterProductViewModel.Description!,
				Price = RegisterProductViewModel.Price,
				Discount = RegisterProductViewModel.Discount,
				CategoryId = RegisterProductViewModel.CategoryId,
				ProductImage = RegisterProductViewModel.ProductImage,
			};
		}
	}
}
