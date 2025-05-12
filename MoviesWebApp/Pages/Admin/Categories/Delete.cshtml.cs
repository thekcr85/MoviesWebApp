using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Movies.DataAccess.Data;
using Movies.DataAccess.Repository.IRepository;
using Movies.Models;

namespace MoviesWebApp.Pages.Admin.Categories
{
	public class DeleteModel : PageModel
	{
		private readonly IUnitOfWork _unitOfWork;
		public DeleteModel(IUnitOfWork unitOdWork)
		{
			_unitOfWork = unitOdWork;
		}

		[BindProperty]
		public Category Category { get; set; }

		public void OnGet(int id)
		{
			Category = _unitOfWork.Category.GetFirstOrDefault(u => u.Id == id);
		}

		public IActionResult OnPost()
		{

			var categoryFromDb = _unitOfWork.Category.GetFirstOrDefault(u => u.Id == Category.Id);
			if (categoryFromDb is not null)
			{
				_unitOfWork.Category.Remove(categoryFromDb);
				_unitOfWork.Save();
				TempData["success"] = "Category deleted successfully";
				return RedirectToPage("Index");
			}
			return Page();

		}
	}


}
