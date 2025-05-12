using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movies.Models
{
	public class Movie
	{
		[Key]
		public int Id { get; set; }

		[Required(ErrorMessage = "Please enter the title of the movie.")]
		[MaxLength(100, ErrorMessage = "The title cannot exceed 100 characters.")]
		[MinLength(2, ErrorMessage = "The title must be at least 2 characters long.")]
		[Display(Name = "Movie Title")]
		public string Title { get; set; }

		[Required(ErrorMessage = "Please enter the director's name.")]
		[MaxLength(50, ErrorMessage = "The director's name cannot exceed 50 characters.")]
		[MinLength(2, ErrorMessage = "The director's name must be at least 2 characters long.")]
		public string Director { get; set; }

		[Required(ErrorMessage = "Please enter the release date.")]
		[Display(Name = "Release Date")]
		public DateTime ReleaseDate { get; set; }

		public string Description { get; set; }

		[Required]
		public string Image { get; set; }

		// FOREIGN KEYS
		[Display(Name = "Category")]
		public int CategoryId { get; set; }
		[Display(Name = "Distributor")]
		public int DistributorId { get; set; }
		[Display(Name = "Format")]
		public int FormatId { get; set; }

		// NAVIGATION PROPERTIES
		public virtual Category Category { get; set; }
		public virtual Distributor Distributor { get; set; }
		public virtual Format Format { get; set; }
	}
}
