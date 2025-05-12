using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Movies.DataAccess.Data;
using Movies.DataAccess.Repository.IRepository;
using Movies.Models;

namespace MoviesWebApp.Pages.Admin.Formats
{
    public class EditModel : PageModel
    {
		private readonly IUnitOfWork _unitOfWork;
		public EditModel(IUnitOfWork unitOfWork)
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
			if (ModelState.IsValid)
			{
				_unitOfWork.Format.Update(Format);
				_unitOfWork.Save();
				TempData["success"] = "Format updated successfully";
				return RedirectToPage("Index");
			}
			return Page();
		}
    }


}
