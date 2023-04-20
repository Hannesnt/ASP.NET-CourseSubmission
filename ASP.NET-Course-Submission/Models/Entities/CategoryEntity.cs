using ASP.NET_Course_Submission.Models.Interfaces;

namespace ASP.NET_Course_Submission.Models.Entities
{
    public class CategoryEntity : ICategory
    {
        public int Id { get; set; }
        public string CategoryName { get; set; } = null!;

        public ICollection<ProductEntity> Products = new HashSet<ProductEntity>();


    }
}
