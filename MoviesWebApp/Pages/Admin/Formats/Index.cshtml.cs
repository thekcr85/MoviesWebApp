using Microsoft.AspNetCore.Mvc.RazorPages;
using Movies.DataAccess.Data;
using Movies.DataAccess.Repository.IRepository;
using Movies.Models;

namespace MoviesWebApp.Pages.Admin.Formats
{
    public class IndexModel : PageModel
    {
		private readonly IUnitOfWork _unitOfWork;
		public IndexModel(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}

		public IEnumerable<Format> Formats;

		public void OnGet()
        {
			Formats = _unitOfWork.Format.GetAll();
		}
    }
}
