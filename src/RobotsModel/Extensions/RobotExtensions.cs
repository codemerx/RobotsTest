namespace RobotsModel.Extensions
{
    public static class RobotExtensions
    {
        public static RobotsData.Models.Robot ToDbRobot(this Robot robot, bool isLost, int gridId)
        {
            return new RobotsData.Models.Robot()
            {
                Orientation = robot.Orientation,
                XPosition = robot.XPosition,
                YPosition = robot.YPosition,
                IsLost = isLost,
                GridId = gridId,
            };
        }

        public static RobotResponse FromDbRobot(this RobotsData.Models.Robot robot)
        {
            return new RobotResponse()
            {
                Orientation = (char)robot.Orientation,
                XPosition = robot.XPosition,
                YPosition = robot.YPosition,
                IsLost = robot.IsLost,
            };
        }
    }
}
