using ASP.NET_Course_Submission.Models.Interfaces;
using ASP.NET_Course_Submission.Models.ViewModels;

namespace ASP.NET_Course_Submission.Models.Entities
{
    public class CategoryEntity : ICategory
    {
        public int Id { get; set; }
        public string CategoryName { get; set; } = null!;

        public ICollection<ProductEntity> Products = new HashSet<ProductEntity>();

        public static implicit operator CategoryViewModel(CategoryEntity entity)
        {
            return new CategoryViewModel
            {
                Id = entity.Id,
                CategoryName = entity.CategoryName,

            };
        }
    }
}
