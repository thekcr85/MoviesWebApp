using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movies.DataAccess.Repository.IRepository
{
	public interface IUnitOfWork : IDisposable
	{
		ICategoryRepository Category { get; }
		IDistributorRepository Distributor { get; }
		IFormatRepository Format { get; }
		IMovieRepository Movie { get; }
		void Save();
	}
}
