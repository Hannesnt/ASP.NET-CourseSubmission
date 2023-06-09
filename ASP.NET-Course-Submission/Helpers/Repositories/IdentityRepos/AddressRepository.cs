﻿using ASP.NET_Course_Submission.Models.Context;
using ASP.NET_Course_Submission.Models.Entities;
using ASP.NET_Course_Submission.Models.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace ASP.NET_Course_Submission.Helpers.Repositories.IdentityRepos
{
	public class AddressRepository : IdentityRepository<AddressEntity>
	{

		public AddressRepository(IdentityContext context) : base(context)
		{
			
		}
	}
}
