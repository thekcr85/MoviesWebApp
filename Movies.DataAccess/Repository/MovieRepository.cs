using Microsoft.SqlServer.Server;
using Movies.DataAccess.Data;
using Movies.DataAccess.Repository.IRepository;
using Movies.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movies.DataAccess.Repository
{
	public class MovieRepository : Repository<Movie>, IMovieRepository
	{
		private readonly ApplicationDbContext _db;
		public MovieRepository(ApplicationDbContext db) : base(db)
		{
			_db = db;
		}
		public void Update(Movie movie)
		{
			var movieFromDb = _db.Movie.FirstOrDefault(c => c.Id == movie.Id);
			movieFromDb.Title = movie.Title;
			movieFromDb.Director = movie.Director;
			movieFromDb.ReleaseDate = movie.ReleaseDate;
			movieFromDb.Description = movie.Description;
			movieFromDb.CategoryId = movie.CategoryId;
			movieFromDb.DistributorId = movie.DistributorId;
			movieFromDb.FormatId = movie.FormatId;
			if (movieFromDb.Image is not null)
			{
				movieFromDb.Image = movie.Image;
			}
		}
	}
}
