namespace RobotsData.Models
{
    public class Robot
    {
        public int Id { get; set; }

        public int XPosition { get; set; }

        public int YPosition { get; set; }

        public bool IsLost { get; set; }

        public Orientation Orientation { get; set; }

        public int GridId { get; set; }

        public Grid Grid { get; set; } = null!;
    }
}