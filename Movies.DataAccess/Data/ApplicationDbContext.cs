using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Movies.Models;

namespace Movies.DataAccess.Data
{
	public class ApplicationDbContext : IdentityDbContext
	{
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
		{
		}
		
		public DbSet<Category> Category { get; set; }
		public DbSet<Distributor> Distributor { get; set; }
		public DbSet<Format> Format { get; set; }
		public DbSet<Movie> Movie { get; set; }
		public DbSet<ApplicationUser> ApplicationUser { get; set; }

	}
}
