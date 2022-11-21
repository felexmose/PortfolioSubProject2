

namespace WebServer1.Models
{
    public class MovieModel
    {
        public string Url { get; set; }
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
