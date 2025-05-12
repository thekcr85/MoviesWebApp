using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Movies.DataAccess.Repository.IRepository;
using Movies.Models;

namespace MoviesWebApp.Pages.Admin.Movies
{
	public class IndexModel : PageModel
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly IWebHostEnvironment _webHostEnvironment;
		public IndexModel(IUnitOfWork unitOfWork, IWebHostEnvironment webHostEnvironment)
		{
			_unitOfWork = unitOfWork;
			_webHostEnvironment = webHostEnvironment;
		}

		[BindProperty]
		public IEnumerable<Movie> Movies { get; set; }
		public void OnGet()
		{
			Movies = _unitOfWork.Movie.GetAll(includeProperties: "Category,Distributor,Format");
		}
		public IActionResult OnPostDelete(int id)
		{
			var movieFromDb = _unitOfWork.Movie.GetFirstOrDefault(m => m.Id == id);
			if (movieFromDb != null)
			{
				_unitOfWork.Movie.Remove(movieFromDb);
				var oldImagePath = Path.Combine(_webHostEnvironment.WebRootPath, movieFromDb.Image.TrimStart('\\'));
				if (System.IO.File.Exists(oldImagePath))
				{
					System.IO.File.Delete(oldImagePath);
				}
				TempData["success"] = "Movie deleted successfully";
				_unitOfWork.Save();
				return RedirectToPage();
			}
			return Page();
		}

	}
}
