using RobotsData.Models;

namespace RobotsParser.Abstract
{
    public interface IOrientationParser
    {
        Orientation Parse(string orientation);
    }
}
