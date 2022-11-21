using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Models
{
    public class SearchHistory
    {   
        public int Id { get; set; }
        public int UserId { get; set; }
        public string MovieId { get; set; }
    }
}
