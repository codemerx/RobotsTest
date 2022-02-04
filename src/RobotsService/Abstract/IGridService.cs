using RobotsModel;

namespace RobotsService.Abstract
{
    public interface IGridService
    {
        Task<GridResponse> SynchronizeGrid(Grid grid);

        Task<GridResponse> GetGrid(int gridId);
    }
}
