﻿using RobotsModel;
using RobotsService.Abstract;
using RobotsData;
using RobotsModel.Extensions;
using Microsoft.EntityFrameworkCore;
using RobotsService.Exceptions;
using RobotsData.Models;

namespace RobotsService
{
    public class GridService : IGridService
    {
        private readonly RobotsContext robotsContext;

        public GridService(RobotsContext robotsContext)
        {
            this.robotsContext = robotsContext;
        }

        public async Task<GridResponse> SynchronizeGrid(GridInput grid)
        {
            int? gridId = await this.GetGridIdOrDefaultBySize(grid);
            if (gridId == null)
            {
                gridId = await this.AddGrid(grid);
            }

            HashSet<Scent> scents = new();
            List<RobotResponse> robotResponse = new();
            foreach (RobotInput robot in grid.Robots)
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

                this.robotsContext.Robots.Add(robot.ToDbRobot(isLost, (int)gridId));

                robotResponse.Add(new RobotResponse()
                {
                    IsLost = isLost,
                    Orientation = (char)robot.Orientation,
                    XPosition = robot.XPosition,
                    YPosition = robot.YPosition,
                });
            }

            await this.robotsContext.SaveChangesAsync();

            GridResponse gridResponse = new GridResponse()
            {
                Id = (int)gridId,
                Robots = robotResponse,
                XSize = grid.XSize,
                YSize = grid.YSize,
            };

            return gridResponse;
        }

        public async Task<GridResponse> GetGrid(int gridId)
        {
            Grid? grid = await this.robotsContext.Grids
                .Include(g => g.Robots)
                .FirstOrDefaultAsync(g => g.Id == gridId);
            if (grid == null)
            {
                throw new GridNotFoundException($"The grid with id: {gridId} does not exist");
            }

            return grid.FromDbGrid();
        }

        private async Task<int?> GetGridIdOrDefaultBySize(GridInput grid)
        {
            var dbGrid = await this.robotsContext.Grids
                .FirstOrDefaultAsync(g => g.XSize == grid.XSize && g.YSize == grid.YSize);

            return dbGrid?.Id;
        }

        private async Task<int> AddGrid(GridInput grid)
        {
            var dbGrid = grid.ToDbGrid();

            await this.robotsContext.Grids.AddAsync(dbGrid);

            await this.robotsContext.SaveChangesAsync();

            return dbGrid.Id;
        }

        private static bool IsOutOfBoundaries(RobotInput robot, int xSize, int ySize)
        {
            return robot.XPosition < 0 
                || robot.YPosition < 0
                || robot.XPosition > xSize
                || robot.YPosition > ySize;
        }

        private static void ChangePosition(RobotInput robot)
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

        private static void ToLeft(RobotInput robot)
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

        private static void ToRight(RobotInput robot)
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