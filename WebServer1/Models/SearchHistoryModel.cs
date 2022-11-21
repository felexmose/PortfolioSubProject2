using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebServer1.Models
{
    public class SearchHistoryModel
    {   
        public string Url { get; set; }
        public int UserId { get; set; }
        public string MovieId { get; set; }
    }
}
