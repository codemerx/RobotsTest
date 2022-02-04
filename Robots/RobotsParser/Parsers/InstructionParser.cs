using RobotsModels;
using RobotsParser.Abstract;
using RobotsParser.Exceptions;

namespace RobotsParser.Parsers
{
    public class InstructionParser : IInstructionParser
    {
        public Instruction Parse(string instruction)
        {
            switch (instruction)
            {
                case "F": return Instruction.Forward;
                case "R": return Instruction.Right;
                case "L": return Instruction.Left;
                default: throw new InvalidInstructionException($"Unknown instruction: {instruction}");
            }
        }
    }
}
