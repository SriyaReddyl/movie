using Microsoft.EntityFrameworkCore;
using MovieManagement.DataDBContext;
using MovieManagement.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieManagement.Services
{
    public class MovieService
    {
        private readonly MovieDBContext _dbContext;

        public MovieService(MovieDBContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<List<Movie>> GetMovies()
        {
            return await _dbContext.Movies.ToListAsync();
        }
    }
}
