using RobotsModel;
using RobotsService.Models;

namespace RobotsService.Abstract
{
    public interface IGridService
    {
        Task<List<RobotPlacement>> SynchronizeGrid(Grid grid);
    }
}
