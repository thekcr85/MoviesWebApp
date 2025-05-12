using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Movies.DataAccess.Data;
using Movies.DataAccess.Repository.IRepository;
using Movies.Models;

namespace MoviesWebApp.Pages.Admin.Distributors
{
    public class EditModel : PageModel
    {
		private readonly IUnitOfWork _unitOfWork;
		public EditModel(IUnitOfWork unitOfWork)
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
			if (ModelState.IsValid)
			{
				_unitOfWork.Distributor.Update(Distributor);
				_unitOfWork.Save();
				TempData["success"] = "Distributor updated successfully";
				return RedirectToPage("Index");
			}
			return Page();
		}
    }


}
