using Movies.DataAccess.Data;
using Movies.DataAccess.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movies.DataAccess.Repository
{
	public class UnitOfWork : IUnitOfWork
	{
		private readonly ApplicationDbContext _db;
		public UnitOfWork(ApplicationDbContext db)
		{
			_db = db;
			Category = new CategoryRepository(_db);
			Distributor = new DistributorRepository(_db);
			Format = new FormatRepository(_db);
			Movie = new MovieRepository(_db);
		}
		public ICategoryRepository Category { get; private set; }
		public IDistributorRepository Distributor { get; private set; }
		public IFormatRepository Format { get; private set; }
		public IMovieRepository Movie { get; private set; }

		public void Dispose()
		{
			_db.Dispose();
		}

		public void Save()
		{
			_db.SaveChanges();
		}
	}
}
