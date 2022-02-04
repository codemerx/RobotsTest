using RobotsCore.Models;
using RobotsModels;

namespace RobotsCore.Abstract
{
    public interface IRobotsEngine
    {
        List<RobotPlacment> Start(Grid grid);
    }
}
