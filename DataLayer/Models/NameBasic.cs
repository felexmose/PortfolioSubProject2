using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Models
{
    public class NameBasic
    {
        public  string Id { get; set; }
        public string PrimaryName { get; set; }
        public string? BirthYear { get; set; }
        public string? DeathYear { get; set; }
        public string? PrimaryProfessions { get; set; }
    }
}
