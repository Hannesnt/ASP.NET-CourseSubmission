﻿using System.ComponentModel.DataAnnotations;
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
		[Display(Name = "Produktbild")]
		public string ProductImage { get; set; } = null!;

		[Required(ErrorMessage = "Du måste välja en kategori")]
		[Display(Name = "Kategori *")]
		public int CategoryId { get; set; } 

		public bool New { get; set; }
		public bool Featured { get; set; }
		public bool Popular { get; set; }

		public static implicit operator ProductEntity(RegisterProductViewModel RegisterProductViewModel)
		{
			return new ProductEntity
			{
				Name = RegisterProductViewModel.Name,
				Description = RegisterProductViewModel.Description,
				Price = RegisterProductViewModel.Price,
				ProductImage = RegisterProductViewModel.ProductImage,
				CategoryId = RegisterProductViewModel.CategoryId,
				New = RegisterProductViewModel.New,
				Featured = RegisterProductViewModel.Featured,
				Popular = RegisterProductViewModel.Popular,
			};
		}
	}
}