using Instruction = RobotsData.Models.Instruction;
using Orientation = RobotsData.Models.Orientation;
using RobotsModel;
using RobotsParser.Abstract;
using RobotsParser.Exceptions;

namespace RobotsParser.Parsers
{
    public class RobotParser : IRobotParser
    {
        private readonly IInstructionParser instructionParser;
        private readonly IOrientationParser orientationParser;

        public RobotParser(IInstructionParser instructionParser, IOrientationParser orientationParser)
        {
            this.instructionParser = instructionParser;
            this.orientationParser = orientationParser;
        }

        public Robot Parse(string robot, string delimiter)
        {
            string[] robotData = robot.Split(delimiter, StringSplitOptions.RemoveEmptyEntries);
            if (robotData.Length != 4
                || !int.TryParse(robotData[0], out int x)
                || !int.TryParse(robotData[1], out int y))
            {
                throw new InvalidRobotException($"The robot with the data: \"{robot}\" is invalid");
            }

            Orientation orientation = orientationParser.Parse(robotData[2]);
            List<Instruction> instructions = new();
            foreach (var instruction in robotData[3])
            {
                instructions.Add(this.instructionParser.Parse(instruction.ToString()));
            }

            return new Robot()
            {
                XPosition = x,
                YPosition = y,
                Instructions = instructions,
                Orientation = orientation,
            };
        }
    }
}
