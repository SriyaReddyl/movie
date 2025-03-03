using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieManagement.Model
{
    public class Seat
    {
        [Key]
        public int Id { get; set; }
        public int Price { get; set; }
        public bool Isbooked { get; set; }
        [ForeignKey("Theater")]
        public int TheaterId { get; set; }
        public Theater? Theater { get; set; }
    }
}
