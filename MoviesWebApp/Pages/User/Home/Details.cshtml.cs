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

		// Metoda OnGet dla szczegó³ów filmu
		public IActionResult OnGet(int id)
		{
			// Pobranie szczegó³ów filmu po Id z repozytorium przy u¿yciu UnitOfWork
			Movie = _unitOfWork.Movie.GetFirstOrDefault(
				m => m.Id == id, includeProperties:"Category,Distributor,Format"
			);

			if (Movie == null)
			{
				return NotFound(); // Zwrócenie 404, jeœli film nie zosta³ znaleziony
			}

			return Page(); // Zwrot strony, gdy film zostanie znaleziony
		}
	}
}
