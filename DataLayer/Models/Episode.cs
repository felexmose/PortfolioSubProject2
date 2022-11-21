namespace DataLayer.Models
{
    public class Episode
    {
        public string Id { get; set; }
        public string ParentId  { get; set; }
        public int? SeasonNumber { get; set; }
        public int? EpisodeNumber { get; set; }
    }
}
