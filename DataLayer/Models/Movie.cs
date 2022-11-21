

namespace DataLayer.Models
{
    public class Movie
    {
        public string Id { get; set; }
        public string Type { get; set; }
        public string PrimaryTitle { get; set; }
        public string OriginalTitle { get; set; }
        public bool IsAdult { get; set; }        
        public string StartYear { get; set; }
        public string EndYear { get; set; }
        public int? RunTimeMinutes { get; set; }
        public string Genres { get; set; }
    }
}
