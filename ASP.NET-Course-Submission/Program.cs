
using ASP.NET_Course_Submission.Helpers.Repositories.IdentityRepos;
using ASP.NET_Course_Submission.Helpers.Services;
using ASP.NET_Course_Submission.Models.Context;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using WebApp.Factories;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();
builder.Services.AddIdentity<IdentityUser, IdentityRole>(x =>
{
	x.SignIn.RequireConfirmedAccount = false;
	x.User.RequireUniqueEmail = false;
	x.Password.RequiredLength = 8;
}).AddEntityFrameworkStores<IdentityContext>()
   .AddClaimsPrincipalFactory<CustomClaimsPrincipalFactory>();

builder.Services.AddDbContext<IdentityContext>(x => x.UseSqlServer(builder.Configuration.GetConnectionString("IdentitySql")));
builder.Services.AddDbContext<DataContext>(x => x.UseSqlServer(builder.Configuration.GetConnectionString("Sql")));
builder.Services.AddScoped<AddressRepository>();
builder.Services.AddScoped<ProfileRepository>();
builder.Services.AddScoped<AuthService>();
builder.Services.AddScoped<UserService>();
builder.Services.AddScoped<SeedService>();

var app = builder.Build();
app.UseHsts();
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();

app.MapControllerRoute(
	name: "default",
	pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
