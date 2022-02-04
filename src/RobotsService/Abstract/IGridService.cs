using RobotsModel;

namespace RobotsService.Abstract
{
    public interface IGridService
    {
        Task<GridResponse> SynchronizeGrid(GridInput grid);

        Task<GridResponse> GetGrid(int gridId);
    }
}
