namespace WebServer1.Models
{
    public class EpisodeModel
    {
        public string Url { get; set; }
        public string ParentId  { get; set; }
        public int? SeasonNumber { get; set; }
        public int? EpisodeNumber { get; set; }
    }
}
