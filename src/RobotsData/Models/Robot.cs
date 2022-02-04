namespace RobotsData.Models
{
    public class Robot
    {
        public int Id { get; set; }

        public int XLocation { get; set; }

        public int YLocation { get; set; }

        public Orientation Orientation { get; set; }

        public int GridId { get; set; }

        public Grid Grid { get; set; } = null!;
    }
}