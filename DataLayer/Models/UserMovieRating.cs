using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Models
{
    public class UserMovieRating
    {
        public int? Id { get; set; }
        public int UserId { get; set; }
        public string MovieId { get; set; }
        public Double Rating { get; set; }
    }
}
