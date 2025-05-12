using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MoviesWebApp.Pages
{
    public class IndexModel(ILogger<IndexModel> logger) : PageModel
    {
		public IActionResult OnGet()
        {
            return RedirectToPage("User/Home/Index");
		}
    }
}
