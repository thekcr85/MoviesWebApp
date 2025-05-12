﻿using Movies.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movies.DataAccess.Repository.IRepository
{
	public interface IMovieRepository : IRepository<Movie>
	{
		void Update(Movie movie);
	}
}
