using RobotsModels;

namespace RobotsParser.Abstract
{
    public interface IOrientationParser
    {
        Orientation Parse(string orientation);
    }
}
