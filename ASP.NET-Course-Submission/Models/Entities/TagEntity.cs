namespace ASP.NET_Course_Submission.Models.Entities
{
	public class TagEntity
	{
		public int Id { get; set; }

		public string Name { get; set; } = null!;

		public ICollection<ProductTagEntity> ProductTags { get; set; } = new HashSet<ProductTagEntity>();
	}
}
