using ASP.NET_Course_Submission.Helpers.Repositories.ContextRepos;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ASP.NET_Course_Submission.Helpers.Services
{
	public class TagService
	{
		private readonly TagRepository _tagRepository;

		public TagService(TagRepository tagRepository)
		{
			_tagRepository = tagRepository;
		}

		public async Task<List<SelectListItem>> GetTagsAsync()
		{
			var tags = new List<SelectListItem>();

			foreach(var tag in await _tagRepository.GetAllAsync())
			{
				tags.Add(new SelectListItem
				{
					Value = tag.Id.ToString(),
					Text = tag.Name
				});
			}
			return tags;
		}

		public async Task<List<SelectListItem>> GetTagsAsync(string[] selectedTags)
		{
			var tags = new List<SelectListItem>();

			foreach (var tag in await _tagRepository.GetAllAsync())
			{
				tags.Add(new SelectListItem
				{
					Value = tag.Id.ToString(),
					Text = tag.Name,
					Selected = selectedTags.Contains(tag.Id.ToString())
				});
			}
			return tags;
		}
	}
}
