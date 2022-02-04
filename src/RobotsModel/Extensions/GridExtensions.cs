namespace RobotsModel.Extensions
{
    public static class GridExtensions
    {
        public static RobotsData.Models.Grid ToDbGrid(this Grid grid)
        {
            return new RobotsData.Models.Grid()
            {
                XSize = grid.XSize,
                YSize = grid.YSize,
            };
        }

        public static GridResponse FromDbGrid(this RobotsData.Models.Grid grid)
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
