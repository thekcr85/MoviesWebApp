using Movies.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movies.DataAccess.Repository.IRepository
{
	public interface IFormatRepository : IRepository<Format>
	{
		void Update(Format format);
	}
}
