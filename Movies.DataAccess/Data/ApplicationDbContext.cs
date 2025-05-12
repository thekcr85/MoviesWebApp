using Microsoft.EntityFrameworkCore;
using Movies.Models;

namespace Movies.DataAccess.Data
{
	public class ApplicationDbContext : DbContext
	{
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
		{
		}
		
		public DbSet<Category> Category { get; set; }
		public DbSet<Distributor> Distributor { get; set; }
		public DbSet<Format> Format { get; set; }
		public DbSet<Movie> Movie { get; set; }
	}
}
