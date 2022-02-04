using RobotsData.Models;

namespace RobotsModel
{
    public class RobotInput
    {
        public int XPosition { get; set; }

        public int YPosition { get; set; }

        public Orientation Orientation { get; set; }

        public List<Instruction> Instructions { get; set; } = null!;
    }
}
