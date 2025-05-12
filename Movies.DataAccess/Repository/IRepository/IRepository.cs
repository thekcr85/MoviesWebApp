using Movies.DataAccess.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Movies.DataAccess.Repository.IRepository
{
	public interface IRepository<T> where T : class
	{
		// CREATE
		void Add(T entity);

		// READ
		IEnumerable<T> GetAll(string? includeProperties = null);
		T GetFirstOrDefault(Expression<Func<T, bool>>? filter = null, string? includeProperties = null);

		// DELETE
		void Remove(T entity);
		void RemoveRange(IEnumerable<T> entity);
	}
}
