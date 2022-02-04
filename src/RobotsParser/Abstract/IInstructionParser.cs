using RobotsData.Models;

namespace RobotsParser.Abstract
{
    public interface IInstructionParser
    {
        Instruction Parse(string instruction);
    }
}
