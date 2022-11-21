namespace WebServer1.Models
{
    public class RatingCreateModel
    {
        public int UserId { get; set; }
        public string MovieId { get; set; }
        public Double Rating { get; set; }
    }
}
