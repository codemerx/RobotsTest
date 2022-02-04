using RobotsModel;
using RobotsParser.Abstract;
using RobotsParser.Exceptions;

namespace RobotsParser.Parsers
{
    public class OrientationParser : IOrientationParser
    {
        public Orientation Parse(string orientation)
        {
            switch (orientation)
            {
                case "S": return Orientation.South;
                case "N": return Orientation.North;
                case "W": return Orientation.West;
                case "E": return Orientation.East;
                default: throw new InvalidOrientationException($"Unknown orientation: {orientation}");
            }
        }
    }
}
