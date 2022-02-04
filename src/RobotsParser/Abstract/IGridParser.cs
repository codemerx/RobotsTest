using RobotsModel;

namespace RobotsParser.Abstract
{
    public interface IGridParser
    {
        GridInput Parse(string input, string delimiter);
    }
}