using Movies.DataAccess.Data;
using Movies.DataAccess.Repository.IRepository;
using Movies.Models;

namespace Movies.DataAccess.Repository
{
	public class DistributorRepository : Repository<Distributor>, IDistributorRepository
	{
		private readonly ApplicationDbContext _db;
		public DistributorRepository(ApplicationDbContext db) : base(db)
		{
			_db = db;
		}

		public void Update(Distributor distributor)
		{
			var distributorFromDb = _db.Distributor.FirstOrDefault(c => c.Id == distributor.Id);
			distributorFromDb.Name = distributor.Name;
		}
	}
}
