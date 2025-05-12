using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Movies.DataAccess.Data;
using Movies.DataAccess.Repository.IRepository;
using Movies.Models;

namespace MoviesWebApp.Pages.Admin.Formats
{
	public class DeleteModel : PageModel
	{
		private readonly IUnitOfWork _unitOfWork;
		public DeleteModel(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}

		[BindProperty]
		public Format Format { get; set; }

		public void OnGet(int id)
		{
			Format = _unitOfWork.Format.GetFirstOrDefault(u => u.Id == id);
		}

		public IActionResult OnPost()
		{

			var formatFromDb = _unitOfWork.Distributor.GetFirstOrDefault(u => u.Id == Format.Id);
			if (formatFromDb is not null)
			{
				_unitOfWork.Distributor.Remove(formatFromDb);
				_unitOfWork.Save();
				TempData["success"] = "Format deleted successfully";
				return RedirectToPage("Index");
			}
			return Page();

		}
	}


}
