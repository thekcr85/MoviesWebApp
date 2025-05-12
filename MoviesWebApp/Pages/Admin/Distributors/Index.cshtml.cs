using Microsoft.AspNetCore.Mvc.RazorPages;
using Movies.DataAccess.Data;
using Movies.DataAccess.Repository.IRepository;
using Movies.Models;

namespace MoviesWebApp.Pages.Admin.Distributors
{
    public class IndexModel : PageModel
    {
		private readonly IUnitOfWork _unitOfWork;
		public IndexModel(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}

		public IEnumerable<Distributor> Distributors;

		public void OnGet()
        {
			Distributors = _unitOfWork.Distributor.GetAll();
		}
    }
}
