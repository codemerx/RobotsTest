namespace RobotsModel
{
    public class GridResponse
    {
        public int Id { get; set; }

        public int XSize { get; set; }

        public int YSize { get; set; }

        public List<RobotResponse> Robots { get; set; } = null!;
    }
}
