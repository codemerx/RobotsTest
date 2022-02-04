using RobotsModel;
using RobotsParser.Abstract;
using RobotsParser.Exceptions;

namespace RobotsParser.Parsers
{
    public class GridParser : IGridParser
    {
        private readonly IRobotParser robotParser;

        public GridParser(IRobotParser robotParser)
        {
            this.robotParser = robotParser;
        }

        public GridInput Parse(string input, string delimiter)
        {
            string[] splittedInput = input.Split(delimiter, StringSplitOptions.RemoveEmptyEntries);

            if (!splittedInput.Any())
            {
                throw new InvalidGridException("The grid is empty");
            }

            // the grid lenght should be always odd and there should be atleast one robot
            if (splittedInput.Length % 2 == 0 || splittedInput.Length < 3)
            {
                throw new InvalidGridException("The grid is in a wrong format");
            }

            GridInput grid = new();
            (grid.XSize, grid.YSize) = GetCoorinates(splittedInput.First());
            grid.Robots = this.GetRobots(splittedInput.Skip(1).ToArray());

            return grid;
        }

        private List<RobotInput> GetRobots(string[] robots)
        {
            List<RobotInput> result = new List<RobotInput>();
            for (int i = 0; i < robots.Length; i += 2)
            {
                RobotInput robot = this.robotParser.Parse($"{robots[i]} {robots[i + 1]}", " ");
                result.Add(robot);
            }

            return result;
        }

        private static (int x, int y) GetCoorinates(string coordinates)
        {
            string[] splittedInput = coordinates.Split(" ", StringSplitOptions.RemoveEmptyEntries);
            if (!splittedInput.Any()
                || splittedInput.Length != 2
                || !int.TryParse(splittedInput[0], out int x)
                || !int.TryParse(splittedInput[1], out int y))
            {
                throw new InvalidGridException("The grid coordinates are in a wrong format");
            }
            
            return (x, y);
        }
    }
}
