using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieManagement.Model;
using MovieManagement.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MovieManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly BookingService _bookingService;

        public BookingController(BookingService bookingService)
        {
            _bookingService = bookingService;
        }
        [HttpGet("user/{id}")]
        public async Task<ActionResult<List<Booking>>> GetBookingsByUserId(int id)
        {
            try
            {
                var bookings = await _bookingService.GetBookingsByUserID(id);
                return Ok(bookings);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error retrieving bookings: {ex.Message}");
            }
        }
        [HttpGet()]
        public async Task<ActionResult<List<Booking>>> GetBookings()
        {
            try
            {
                var bookings = await _bookingService.GetBookings();
                return Ok(bookings);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error retrieving bookings: {ex.Message}");
            }
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Booking>> GetBookingsById(int id)
        {
            try
            {
                var bookings = await _bookingService.GetBookingsById(id);
                return Ok(bookings);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error retrieving bookings: {ex.Message}");
            }
        }
        [HttpGet("/count")]
        public async Task<ActionResult<int>> GetBookingsCount()
        {
            try
            {
                var count = await _bookingService.GetBookingsCount();
                return Ok(count);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error retrieving bookings: {ex.Message}");
            }
        }

        // POST: api/booking
        [HttpPost]
        public async Task<ActionResult<Booking>> AddBooking([FromBody] Booking booking)
        {
            try
            {
                await _bookingService.AddBooking(booking);
                return CreatedAtAction(nameof(GetBookingsByUserId), new { id = booking.MovieUserId }, booking);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error adding booking: {ex.Message}");
            }
        }
    }
}
