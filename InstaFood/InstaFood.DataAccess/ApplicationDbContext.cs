using InstaFood.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace InstaFood.DataAccess
{
	public class ApplicationDbContext : IdentityDbContext
	{
		public DbSet<Category> Category {get; set;}

		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
			: base(options)
		{
		}
	}
}
