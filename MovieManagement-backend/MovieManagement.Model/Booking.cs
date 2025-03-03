
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MovieManagement.Model
{
    public class Booking
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Movie")]
        public int MovieId { get; set; }
        public Movie? Movie { get; set; }

        [ForeignKey("Theater")]
        public int TheaterId { get; set; }
        public Theater? Theater { get; set; }

        [ForeignKey("MovieUser")]
        public Guid MovieUserId { get; set; }
        public MovieUser? MovieUser { get; set; }
        public decimal TotalPrice { get; set; }
        public string BookedSeats { get; set; }

        public async Task<List<Booking>> ToListAsync()
        {
            throw new NotImplementedException();
        }
    }
}
