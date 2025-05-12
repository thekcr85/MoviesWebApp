using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Movies.DataAccess.Data;
using Movies.DataAccess.Repository.IRepository;
using Movies.Models;

namespace MoviesWebApp.Pages.Admin.Formats
{
    public class CreateModel : PageModel
    {
		private readonly IUnitOfWork _unitOfWork;
		public CreateModel(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}

		[BindProperty]
		public Format Format { get; set; }
		public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost()
		{
			if (ModelState.IsValid)
			{
				_unitOfWork.Format.Add(Format);
				_unitOfWork.Save();
				TempData["success"] = "Format created successfully";
				return RedirectToPage("Index");
			}
			return Page();
		}
    }


}
