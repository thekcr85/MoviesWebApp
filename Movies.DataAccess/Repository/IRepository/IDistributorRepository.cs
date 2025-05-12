using Movies.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movies.DataAccess.Repository.IRepository
{
	public interface IDistributorRepository : IRepository<Distributor>
	{
		void Update(Distributor distributor);
	}
}
