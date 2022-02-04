using RobotsData.Models;

namespace RobotsModel.Extensions
{
    public static class GridExtensions
    {
        public static Grid ToDbGrid(this GridInput grid)
        {
            return new Grid()
            {
                XSize = grid.XSize,
                YSize = grid.YSize,
            };
        }

        public static GridResponse FromDbGrid(this Grid grid)
        {
            return new GridResponse()
            {
                Id = grid.Id,
                Robots = grid.Robots.Select(r => r.FromDbRobot()).ToList(),
                XSize = grid.XSize,
                YSize = grid.YSize,
            };
        }
    }
}
