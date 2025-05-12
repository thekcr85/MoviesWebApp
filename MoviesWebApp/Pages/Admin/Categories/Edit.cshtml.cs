using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Movies.DataAccess.Data;
using Movies.DataAccess.Repository.IRepository;
using Movies.Models;

namespace MoviesWebApp.Pages.Admin.Categories
{
    public class EditModel : PageModel
    {
		private readonly IUnitOfWork _unitOfWork;
		public EditModel(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}

		[BindProperty]
		public Category Category { get; set; }

		public void OnGet(int id)
        {
			Category = _unitOfWork.Category.GetFirstOrDefault(u => u.Id == id);
		}

        public IActionResult OnPost()
		{
			if (ModelState.IsValid)
			{
				_unitOfWork.Category.Update(Category);
				_unitOfWork.Save();
				TempData["success"] = "Category updated successfully";
				return RedirectToPage("Index");
			}
			return Page();
		}
    }


}
