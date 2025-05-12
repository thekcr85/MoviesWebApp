using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movies.Models
{
	public class Distributor
	{
		[Key]
		public int Id { get; set; }
		[Required(ErrorMessage = "Distributor name is required")]
		[Display(Name = "Distributor Name")]
		public string Name { get; set; }
	}
}
