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
	public class CategoryRepository : Repository<Category>, ICategoryRepository
	{
		private readonly ApplicationDbContext _db;
		public CategoryRepository(ApplicationDbContext db) : base(db)
		{
			_db = db;
		}


		public void Update(Category category)
		{
			var categoryFromDb = _db.Category.FirstOrDefault(c => c.Id == category.Id);
			categoryFromDb.Name = category.Name;
			categoryFromDb.DisplayOrder = category.DisplayOrder;
		}
	}
}
