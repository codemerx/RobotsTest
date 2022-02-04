using RobotsModel;

namespace RobotsParser.Abstract
{
    public interface IGridParser
    {
        Grid Parse(string input, string delimiter);
    }
}