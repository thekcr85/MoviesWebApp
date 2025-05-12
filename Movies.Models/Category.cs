using System.ComponentModel.DataAnnotations;

namespace Movies.Models
{
	public class Category
	{
		[Key]
		public int Id { get; set; }
		[Required(ErrorMessage = "Name is required")]
		[Display(Name = "Category Name")]
		public string Name { get; set; }
		[Display(Name = "Display Order")]
		[Range(1, 100, ErrorMessage = "Display Order must be between 1 and 50")]
		public int DisplayOrder { get; set; }


	}
}
