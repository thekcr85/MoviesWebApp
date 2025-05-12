using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Movies.DataAccess.Data;
using Movies.DataAccess.Repository.IRepository;
using Movies.Models;

namespace MoviesWebApp.Pages.Admin.Distributors
{
	public class DeleteModel : PageModel
	{
		private readonly IUnitOfWork _unitOfWork;
		public DeleteModel(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}

		[BindProperty]
		public Distributor Distributor { get; set; }

		public void OnGet(int id)
		{
			Distributor = _unitOfWork.Distributor.GetFirstOrDefault(u => u.Id == id);
		}

		public IActionResult OnPost()
		{

			var distributorFromDb = _unitOfWork.Distributor.GetFirstOrDefault(u => u.Id == Distributor.Id);
			if (distributorFromDb is not null)
			{
				_unitOfWork.Distributor.Remove(distributorFromDb);
				_unitOfWork.Save();
				TempData["success"] = "Distributor deleted successfully";
				return RedirectToPage("Index");
			}
			return Page();

		}
	}


}
