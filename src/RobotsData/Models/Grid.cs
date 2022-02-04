namespace RobotsData.Models
{
    public class Grid
    {
        public Grid()
        {
            this.Robots = new HashSet<Robot>();
        }

        public int Id { get; set; }

        public int XSize { get; set; }

        public int YSize { get; set; }

        public ICollection<Robot> Robots { get; set; }
    }
}
