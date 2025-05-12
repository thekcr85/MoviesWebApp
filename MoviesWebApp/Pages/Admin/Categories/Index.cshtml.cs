using Microsoft.AspNetCore.Mvc.RazorPages;
using Movies.DataAccess.Data;
using Movies.DataAccess.Repository.IRepository;
using Movies.Models;

namespace MoviesWebApp.Pages.Admin.Categories
{
    public class IndexModel : PageModel
    {
		private readonly IUnitOfWork _unitOfWork;

		public IEnumerable<Category> Categories;
		public IndexModel(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}

		public void OnGet()
        {
			Categories = _unitOfWork.Category.GetAll();
		}
    }
}
