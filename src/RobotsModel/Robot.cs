namespace RobotsModel
{
    public class Robot
    {
        public int XPosition { get; set; }

        public int YPosition { get; set; }

        public Orientation Orientation { get; set; }

        public List<Instruction> Instructions { get; set; } = null!;
    }
}
