using Instruction = RobotsData.Models.Instruction;
using Orientation = RobotsData.Models.Orientation;
using RobotsModel;
using RobotsService.Abstract;
using RobotsService.Models;

namespace RobotsService
{
    public class GridService : IGridService
    {
        public List<RobotPlacment> GetRobotPlacments(Grid grid)
        {
            HashSet<Scent> scents = new();
            List<RobotPlacment> robotPlacments = new();
            foreach (Robot robot in grid.Robots)
            {
                bool isLost = false;
                int xLastPosition = robot.XPosition;
                int yLastPosition = robot.YPosition;
                foreach (var instruction in robot.Instructions)
                {
                    if (Instruction.Forward == instruction)
                    {
                        Scent scent = new(robot.XPosition, robot.YPosition, robot.Orientation);
                        if (!scents.Contains(scent))
                        {
                            xLastPosition = robot.XPosition;
                            yLastPosition = robot.YPosition;
                            ChangePosition(robot);
                        }

                        if (IsOutOfBoundaries(robot, grid.XSize, grid.YSize))
                        {
                            scents.Add(scent);
                            isLost = true;
                            // Reverting the position
                            robot.XPosition = xLastPosition;
                            robot.YPosition = yLastPosition;

                            break;
                        }
                    }
                    else if(Instruction.Left == instruction)
                    {
                        ToLeft(robot);
                    }
                    else if(Instruction.Right == instruction)
                    {
                        ToRight(robot);
                    }
                }

                robotPlacments.Add(new RobotPlacment()
                {
                    IsLost = isLost,
                    Orientation = (char)robot.Orientation,
                    XLocation = robot.XPosition,
                    YLocation = robot.YPosition,
                });
            }

            return robotPlacments;
        }

        private static bool IsOutOfBoundaries(Robot robot, int xSize, int ySize)
        {
            return robot.XPosition < 0 
                || robot.YPosition < 0
                || robot.XPosition > xSize
                || robot.YPosition > ySize;
        }

        private static void ChangePosition(Robot robot)
        {
            switch (robot.Orientation)
            {
                case Orientation.North:
                    robot.YPosition++;
                    break;
                case Orientation.South:
                    robot.YPosition--;
                    break;
                case Orientation.West:
                    robot.XPosition--;
                    break;
                case Orientation.East:
                    robot.XPosition++;
                    break;
            }
        }

        private static void ToLeft(Robot robot)
        {
            switch (robot.Orientation)
            {
                case Orientation.North:
                    robot.Orientation = Orientation.West;
                    break;
                case Orientation.South:
                    robot.Orientation = Orientation.East;
                    break;
                case Orientation.West:
                    robot.Orientation = Orientation.South;
                    break;
                case Orientation.East:
                    robot.Orientation = Orientation.North;
                    break;
            }
        }

        private static void ToRight(Robot robot)
        {
            switch (robot.Orientation)
            {
                case Orientation.North:
                    robot.Orientation = Orientation.East;
                    break;
                case Orientation.South:
                    robot.Orientation = Orientation.West;
                    break;
                case Orientation.West:
                    robot.Orientation = Orientation.North;
                    break;
                case Orientation.East:
                    robot.Orientation = Orientation.South;
                    break;
            }
        }
    }
}