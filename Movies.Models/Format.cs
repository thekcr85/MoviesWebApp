using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movies.Models
{
	public class Format
	{
		[Key]
		public int Id { get; set; }
		[Required(ErrorMessage = "Please enter movie's format.")]
		[MaxLength(50, ErrorMessage = "Movie format cannot exceed 50 characters.")]
		[MinLength(2, ErrorMessage = "Movie format must be at least 2 characters long.")]
		[Display(Name = "Format")]
		public string Name { get; set; }
	}
}
