using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Movies.DataAccess.Repository.IRepository;
using Movies.Models;

namespace MoviesWebApp.Pages.User.Home
{
    public class IndexModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;
        public IndexModel(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}
		public IEnumerable<Movie> MovieList { get; set; }
		public IEnumerable<Category> CategoryList { get; set; }
		public void OnGet()
        {
			MovieList = _unitOfWork.Movie.GetAll(includeProperties: "Category,Distributor,Format");
			CategoryList = _unitOfWork.Category.GetAll();
		}
		public IActionResult OnPostDelete(int id)
		{
			var movie = _unitOfWork.Movie.GetFirstOrDefault(m => m.Id == id);
			if (movie == null)
			{
				return NotFound();
			}

			_unitOfWork.Movie.Remove(movie);
			_unitOfWork.Save();
			return RedirectToPage(); // Przekierowanie na stronê g³ówn¹
		}
	}
}
