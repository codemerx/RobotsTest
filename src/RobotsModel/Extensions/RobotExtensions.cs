using RobotsData.Models;

namespace RobotsModel.Extensions
{
    public static class RobotExtensions
    {
        public static Robot ToDbRobot(this RobotInput robot, bool isLost, int gridId)
        {
            return new Robot()
            {
                Orientation = robot.Orientation,
                XPosition = robot.XPosition,
                YPosition = robot.YPosition,
                IsLost = isLost,
                GridId = gridId,
            };
        }

        public static RobotResponse FromDbRobot(this Robot robot)
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
