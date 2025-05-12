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
	public class FormatRepository : Repository<Format>, IFormatRepository
	{
		private readonly ApplicationDbContext _db;
		public FormatRepository(ApplicationDbContext db) : base(db)
		{
			_db = db;
		}
		public void Update(Format format)
		{
			var formatFromDb = _db.Format.FirstOrDefault(c => c.Id == format.Id);
			formatFromDb.Name = format.Name;		}
	}
}
