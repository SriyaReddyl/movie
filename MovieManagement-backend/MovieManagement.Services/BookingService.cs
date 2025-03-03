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
    public class BookingService
    {
        private readonly MovieDBContext _dbcontext;
        public BookingService(MovieDBContext dBContext)
        {
            _dbcontext = dBContext;
        }
        public async Task<List<Booking>> GetBookingsByUserID(int id)
        {
            return await _dbcontext.Bookings.Where(b => b.MovieUserId.Equals(id)).ToListAsync();
        }
        public async Task<List<Booking>> GetBookings()
        {
            return await _dbcontext.Bookings.ToListAsync();
        }
        public async Task<Booking> GetBookingsById(int id)
        {
            return await _dbcontext.Bookings.FirstOrDefaultAsync(b => b.Id == id);
        }
        
            public async Task<int> GetBookingsCount()
        {
            return await _dbcontext.Bookings.CountAsync();
        }
        public async Task AddBooking(Booking booking)
        {
             await _dbcontext.Bookings.AddAsync(booking);
            _dbcontext.SaveChanges();
        }
    }
}
