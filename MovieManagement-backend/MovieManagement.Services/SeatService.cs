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
    public class SeatService
    {
        private MovieDBContext _dbContext;
        public SeatService(MovieDBContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<List<Seat>> GetAllSeats()
        {
            return await _dbContext.Seats.Include(t => t.Theater).Include(t => t.Theater.Movie).ToListAsync();
        }
        public async Task<List<Seat>> GetSeatsByTheaterId(int id)
        {
            return await _dbContext.Seats.Include(t => t.Theater).Include(t => t.Theater.Movie).Where(t => t.TheaterId == id).ToListAsync();
        }
        public void updateSeat(int id , Seat seat)
        {
            Seat seat1 = _dbContext.Seats.FirstOrDefault(t => t.Id == id);
            seat1.Isbooked = seat.Isbooked;
            seat1.Price = seat.Price;
            seat1.TheaterId = seat.TheaterId;
            _dbContext.SaveChanges();
        }
        public void BookSeat(int id)
        {
            _dbContext.Seats.FirstOrDefault(t => t.Id == id).Isbooked = true;
            _dbContext.SaveChanges();
        }
        public void UnBookSeat(int id)
        {
            _dbContext.Seats.FirstOrDefault(t => t.Id == id).Isbooked = false;
            _dbContext.SaveChanges();
        }
    }
}
