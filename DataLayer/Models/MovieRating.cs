using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Models
{
    public class MovieRating
    {
        public string Id { get; set; }
        public float AverageRating { get; set; }
        public int Votes { get; set; }        
    }
}
