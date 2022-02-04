namespace RobotsService.Models
{
    public class RobotPlacement
    {
        public int XLocation { get; set; }

        public int YLocation { get; set; }

        public char Orientation { get; set; }

        public bool IsLost { get; set; }
    }
}
