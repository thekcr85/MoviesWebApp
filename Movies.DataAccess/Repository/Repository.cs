using Microsoft.EntityFrameworkCore;
using Movies.DataAccess.Data;
using Movies.DataAccess.Repository.IRepository;
using System.Linq.Expressions;

namespace Movies.DataAccess.Repository
{
	public class Repository<T> : IRepository<T> where T : class
	{
		private readonly ApplicationDbContext _db;
		internal DbSet<T> dbSet;
		public Repository(ApplicationDbContext db)
		{
			_db = db;
			this.dbSet = _db.Set<T>();
		}

		public void Add(T entity)
		{
			dbSet.Add(entity);
		}

		public IEnumerable<T> GetAll(string? includeProperties = null)
		{
			IQueryable<T> query = dbSet;
			if (includeProperties is not null)
			{
				foreach (var includeProperty in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
				{
					query = query.Include(includeProperty);
				}
			}
			return query.ToList();
		}

		public T GetFirstOrDefault(Expression<Func<T, bool>>? filter = null, string? includeProperties = null)
		{
			IQueryable<T> query = dbSet;
			if (filter is not null)
			{
				query = query.Where(filter);
			}
			if (includeProperties is not null)
			{
				foreach (var includeProperty in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
				{
					query = query.Include(includeProperty);
				}
			}
			return query.FirstOrDefault();
		}

		public void Remove(T entity)
		{
			dbSet.Remove(entity);
		}

		public void RemoveRange(IEnumerable<T> entity)
		{
			dbSet.RemoveRange(entity);
		}
	}
}
