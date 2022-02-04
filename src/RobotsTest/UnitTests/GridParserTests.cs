using RobotsData.Models;
using RobotsModel;
using RobotsParser.Abstract;
using RobotsParser.Exceptions;
using System;
using Xunit;

namespace UnitTests.RobotsTest
{
    public class GridParserTests
    {
        private readonly IGridParser gridParser;

        public GridParserTests(IGridParser gridParser)
        {
            this.gridParser = gridParser;
        }

        [Fact]
        public void GridParserParse_ShouldSucceed()
        {
            string input = "5 4\r\n1 1 E\r\nRFRFRFRFL\r\n3 0 N\r\nFRRFLLFFRRFLL\r\n5 3 S\r\nLLFFFRFLFL";

            GridInput grid = gridParser.Parse(input, Environment.NewLine);

            Assert.NotNull(grid);
            Assert.Equal(5, grid.XSize);
            Assert.Equal(4, grid.YSize);
            Assert.NotNull(grid.Robots);
            Assert.Equal(3, grid.Robots.Count);
            // First robot
            Assert.Equal(1, grid.Robots[0].XPosition);
            Assert.Equal(1, grid.Robots[0].YPosition);
            Assert.Equal(Orientation.East, grid.Robots[0].Orientation);
            Assert.Equal(9, grid.Robots[0].Instructions.Count);
            Assert.Equal(Instruction.Right, grid.Robots[0].Instructions[0]);
            Assert.Equal(Instruction.Forward, grid.Robots[0].Instructions[1]);
            Assert.Equal(Instruction.Right, grid.Robots[0].Instructions[2]);
            Assert.Equal(Instruction.Forward, grid.Robots[0].Instructions[3]);
            Assert.Equal(Instruction.Right, grid.Robots[0].Instructions[4]);
            Assert.Equal(Instruction.Forward, grid.Robots[0].Instructions[5]);
            Assert.Equal(Instruction.Right, grid.Robots[0].Instructions[6]);
            Assert.Equal(Instruction.Forward, grid.Robots[0].Instructions[7]);
            Assert.Equal(Instruction.Left, grid.Robots[0].Instructions[8]);
            // Second robot
            Assert.Equal(3, grid.Robots[1].XPosition);
            Assert.Equal(0, grid.Robots[1].YPosition);
            Assert.Equal(Orientation.North, grid.Robots[1].Orientation);
            Assert.Equal(13, grid.Robots[1].Instructions.Count);
            Assert.Equal(Instruction.Forward, grid.Robots[1].Instructions[0]);
            Assert.Equal(Instruction.Right, grid.Robots[1].Instructions[1]);
            Assert.Equal(Instruction.Right, grid.Robots[1].Instructions[2]);
            Assert.Equal(Instruction.Forward, grid.Robots[1].Instructions[3]);
            Assert.Equal(Instruction.Left, grid.Robots[1].Instructions[4]);
            Assert.Equal(Instruction.Left, grid.Robots[1].Instructions[5]);
            Assert.Equal(Instruction.Forward, grid.Robots[1].Instructions[6]);
            Assert.Equal(Instruction.Forward, grid.Robots[1].Instructions[7]);
            Assert.Equal(Instruction.Right, grid.Robots[1].Instructions[8]);
            Assert.Equal(Instruction.Right, grid.Robots[1].Instructions[9]);
            Assert.Equal(Instruction.Forward, grid.Robots[1].Instructions[10]);
            Assert.Equal(Instruction.Left, grid.Robots[1].Instructions[11]);
            Assert.Equal(Instruction.Left, grid.Robots[1].Instructions[12]);
            // Third robot
            Assert.Equal(5, grid.Robots[2].XPosition);
            Assert.Equal(3, grid.Robots[2].YPosition);
            Assert.Equal(Orientation.South, grid.Robots[2].Orientation);
            Assert.Equal(10, grid.Robots[2].Instructions.Count);
            Assert.Equal(Instruction.Left, grid.Robots[2].Instructions[0]);
            Assert.Equal(Instruction.Left, grid.Robots[2].Instructions[1]);
            Assert.Equal(Instruction.Forward, grid.Robots[2].Instructions[2]);
            Assert.Equal(Instruction.Forward, grid.Robots[2].Instructions[3]);
            Assert.Equal(Instruction.Forward, grid.Robots[2].Instructions[4]);
            Assert.Equal(Instruction.Right, grid.Robots[2].Instructions[5]);
            Assert.Equal(Instruction.Forward, grid.Robots[2].Instructions[6]);
            Assert.Equal(Instruction.Left, grid.Robots[2].Instructions[7]);
            Assert.Equal(Instruction.Forward, grid.Robots[2].Instructions[8]);
            Assert.Equal(Instruction.Left, grid.Robots[2].Instructions[9]);
        }

        [Fact]
        public void GridParserParse_ShouldThrowInvalidGridException_WhenTheInputIsEmpty()
        {
            Assert.Throws<InvalidGridException>(() => gridParser.Parse(string.Empty, string.Empty));
        }

        [Fact]
        public void GridParserParse_ShouldThrowInvalidGridException_WhenTheGridIsEmpty()
        {
            string input = "2 2";

            Assert.Throws<InvalidGridException>(() => gridParser.Parse(input, string.Empty));
        }

        [Fact]
        public void GridParserParse_ShouldThrowInvalidGridException_WhenTheGridLengthIsEven()
        {
            string input = "2 2 1 2 E FR";

            Assert.Throws<InvalidGridException>(() => gridParser.Parse(input, " "));
        }

        [Fact]
        public void GridParserParse_ShouldThrowArgumentNullException_WhenTheInputIsNull()
        {
            Assert.Throws<ArgumentNullException>(() => gridParser.Parse(null!, " "));
        }

        [Fact]
        public void GridParserParse_ShouldThrowArgumentNullException_WhenTheDelimiterIsNull()
        {
            string input = "2 2 1 2 E FR";

            Assert.Throws<ArgumentNullException>(() => gridParser.Parse(input, null!));
        }
    }
}