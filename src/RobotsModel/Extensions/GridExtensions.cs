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
    }
}
