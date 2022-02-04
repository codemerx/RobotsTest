namespace RobotsModel
{
    public class GridInput
    {
        public int XSize { get; set; }

        public int YSize { get; set; }

        public List<RobotInput> Robots { get; set; } = null!;
    }
}
