using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Movies.DataAccess.Repository.IRepository;
using Movies.Models;
using System.ComponentModel.DataAnnotations;

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

		public IActionResult OnGet(int id)
		{
			Movie = _unitOfWork.Movie.GetFirstOrDefault(m => m.Id == id, includeProperties: "Category,Distributor,Format");

			if (Movie == null)
			{
				return NotFound();
			}

			return Page();
		}
	}
}
