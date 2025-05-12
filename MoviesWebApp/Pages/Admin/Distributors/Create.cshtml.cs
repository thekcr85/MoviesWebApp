using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Movies.DataAccess.Data;
using Movies.DataAccess.Repository.IRepository;
using Movies.Models;

namespace MoviesWebApp.Pages.Admin.Distributors
{
    public class CreateModel : PageModel
    {
		private readonly IUnitOfWork _unitOfWork;
		public CreateModel(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}

		[BindProperty]
		public Distributor Distributor { get; set; }
		public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost()
		{
			if (ModelState.IsValid)
			{
				_unitOfWork.Distributor.Add(Distributor);
				_unitOfWork.Save();
				TempData["success"] = "Distributor created successfully";
				return RedirectToPage("Index");
			}
			return Page();
		}
    }


}
