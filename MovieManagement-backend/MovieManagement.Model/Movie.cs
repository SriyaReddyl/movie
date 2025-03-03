using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieManagement.Model
{
    public class Movie
    {
            [Key]
            public int Id { get; set; }
            public string Title { get; set; }
            public string Genre { get; set; }
            public string Director { get; set; }
            public DateTime ReleaseDate { get; set; }
            public string Description { get; set; }
            public string Image { get; set; }
        
    }
}
