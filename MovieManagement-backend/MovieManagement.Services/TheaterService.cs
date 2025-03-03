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
    public class TheaterService
    {
        private MovieDBContext _dbContext;
        public TheaterService(MovieDBContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<List<Theater>> GetTheater()
        {
            return await _dbContext.Theaters.Include(t=>t.Movie).ToListAsync();
        }

        public async Task<List<Theater>> GetTheaterById(int movieId)
        {
            return await _dbContext.Theaters.Include(t => t.Movie).Where(t => t.MovieId == movieId).ToListAsync();
        }
        public async Task<List<Theater>> GetTheaterByLocation(string location)
        {
            return await _dbContext.Theaters.Include(t => t.Movie).Where(t => t.Location.Equals(location)).ToListAsync();
        }
    }
}
