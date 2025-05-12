using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Movies.DataAccess.Repository.IRepository;
using Movies.Models;

namespace MoviesWebApp.Pages.Admin.Categories
{
    public class CreateModel : PageModel
    {
		private readonly IUnitOfWork _unitOfWork;
		public CreateModel(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}

		[BindProperty]
		public Category Category { get; set; }
		public void OnGet()
        {
        }

        public IActionResult OnPost()
		{
			if (ModelState.IsValid)
			{
				_unitOfWork.Category.Add(Category);
				_unitOfWork.Save();
				TempData["success"] = "Category created successfully";
				return RedirectToPage("Index");
			}
			return Page();
		}
    }


}
