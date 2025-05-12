using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Movies.DataAccess.Data;
using Movies.DataAccess.Repository.IRepository;
using Movies.Models;

namespace MoviesWebApp.Pages.Admin.Movies
{
	[BindProperties]
	public class UpsertModel : PageModel
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly IWebHostEnvironment _webHostEnvironment;
		public UpsertModel(IUnitOfWork unitOfWork, IWebHostEnvironment webHostEnvironment)
		{
			_unitOfWork = unitOfWork;
			_webHostEnvironment = webHostEnvironment;
			Movie = new();
		}

		public Movie Movie { get; set; }
		public IEnumerable<SelectListItem> CategoryList { get; set; }
		public IEnumerable<SelectListItem> DistributorList { get; set; }
		public IEnumerable<SelectListItem> FormatList { get; set; }

		public void OnGet(int? id)
		{
			if (id is not null)
			{
				Movie = _unitOfWork.Movie.GetFirstOrDefault(i => i.Id == id);
			}

			CategoryList = _unitOfWork.Category.GetAll().Select(i => new SelectListItem()
			{
				Text = i.Name,
				Value = i.Id.ToString()
			});
			DistributorList = _unitOfWork.Distributor.GetAll().Select(i => new SelectListItem()
			{
				Text = i.Name,
				Value = i.Id.ToString()
			});
			FormatList = _unitOfWork.Format.GetAll().Select(i => new SelectListItem()
			{
				Text = i.Name,
				Value = i.Id.ToString()
			});

		}

		public async Task<IActionResult> OnPost()
		{
			var webRootPath = _webHostEnvironment.WebRootPath;
			var files = HttpContext.Request.Form.Files;
			if (Movie.Id == 0)
			{
				// create
				var newFileName = Guid.NewGuid().ToString();
				var uploads = Path.Combine(webRootPath, @"images\movies");
				var extension = Path.GetExtension(files[0].FileName);
				using (var fileStreams = new FileStream(Path.Combine(uploads, newFileName + extension), FileMode.Create))
				{
					await files[0].CopyToAsync(fileStreams);
				}
				Movie.Image = @"\images\movies\" + newFileName + extension;
				_unitOfWork.Movie.Add(Movie);
				_unitOfWork.Save();
			}
			else
			{
				var objFromDb = _unitOfWork.Movie.GetFirstOrDefault(i => i.Id == Movie.Id);
				if (files.Count > 0)
				{
					var newFileName = Guid.NewGuid().ToString();
					var uploads = Path.Combine(webRootPath, @"images\movies");
					var extension_new = Path.GetExtension(files[0].FileName);
					var oldImagePath = Path.Combine(webRootPath, objFromDb.Image.TrimStart('\\'));
					if (System.IO.File.Exists(oldImagePath))
					{
						System.IO.File.Delete(oldImagePath);
					}
					using (var fileStreams = new FileStream(Path.Combine(uploads, newFileName + extension_new), FileMode.Create))
					{
						await files[0].CopyToAsync(fileStreams);
					}
					Movie.Image = @"\images\movies\" + newFileName + extension_new;
				}
				else
				{
					Movie.Image = objFromDb.Image;
				}
			}
			return RedirectToPage("./Index");
		}
	}
}
