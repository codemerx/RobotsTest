using RobotsModel;

namespace RobotsParser.Abstract
{
    public interface IRobotParser
    {
        RobotInput Parse(string robot, string delimiter);
    }
}
