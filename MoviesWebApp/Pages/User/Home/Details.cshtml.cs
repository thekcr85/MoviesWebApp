using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Movies.DataAccess.Repository.IRepository;
using Movies.Models;

namespace MoviesWebApp.Pages.User.Home
{
	public class DetailsModel : PageModel
	{
		private readonly IUnitOfWork _unitOfWork;

		public DetailsModel(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}

		public Movie Movie { get; set; }

		// Metoda OnGet dla szczeg��w filmu
		public IActionResult OnGet(int id)
		{
			// Pobranie szczeg��w filmu po Id z repozytorium przy u�yciu UnitOfWork
			Movie = _unitOfWork.Movie.GetFirstOrDefault(
				m => m.Id == id, includeProperties:"Category,Distributor,Format"
			);

			if (Movie == null)
			{
				return NotFound(); // Zwr�cenie 404, je�li film nie zosta� znaleziony
			}

			return Page(); // Zwrot strony, gdy film zostanie znaleziony
		}
	}
}
