using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovieManagement.Model;
using MovieManagement.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MovieManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SeatController : ControllerBase
    {
        private readonly SeatService _seatService;

        public SeatController(SeatService seatService)
        {
            _seatService = seatService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Seat>>> GetAllSeats()
        {
            try
            {
                var seats = await _seatService.GetAllSeats();
                return Ok(seats);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error retrieving seats: {ex.Message}");
            }
        }

        [HttpGet("{theaterId}")]
        public async Task<ActionResult<List<Seat>>> GetSeatsByTheaterId(int theaterId)
        {
            try
            {
                var seats = await _seatService.GetSeatsByTheaterId(theaterId);
                if (seats == null || seats.Count == 0)
                {
                    return NotFound($"No seats found for theater with ID {theaterId}");
                }
                return Ok(seats);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error retrieving seats: {ex.Message}");
            }
        }

        [HttpPost("UpdateSeat/{id}")]
        public IActionResult UpdateSeat(int id, Seat seat)
        {
            _seatService.updateSeat(id, seat);
            return Ok("Seat updated successfully");
        }

        [HttpPost("BookSeat/{id}")]
        public IActionResult BookSeat(int id)
        {
            _seatService.BookSeat(id);
            return Ok("Seat booked successfully");
        }

        [HttpPost("UnBookSeat/{id}")]
        public IActionResult UnBookSeat(int id)
        {
           _seatService.UnBookSeat(id);
            return Ok("Seat unbooked successfully");
        }

    }
}
