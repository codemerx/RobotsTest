using RobotsModel;
using RobotsService.Models;

namespace RobotsService.Abstract
{
    public interface IGridService
    {
        List<RobotPlacment> GetRobotPlacments(Grid grid);
    }
}
