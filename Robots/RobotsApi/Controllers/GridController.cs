using Microsoft.AspNetCore.Mvc;
using RobotsApi.Models;
using RobotsCore.Abstract;
using RobotsCore.Models;
using RobotsModels;
using RobotsParser.Abstract;

namespace RobotsApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GridController : ControllerBase
    {
        private readonly IGridParser gridParser;
        private readonly IRobotsEngine robotsEngine;

        public GridController(IGridParser gridParser, IRobotsEngine robotsEngine)
        {
            this.gridParser = gridParser;
            this.robotsEngine = robotsEngine;
        }

        [HttpPost]
        public async Task<ActionResult<List<RobotPlacment>>> Post([FromBody] StringifiedGrid stringifiedGrid)
        {
            Grid grid = this.gridParser.Parse(stringifiedGrid.Grid, Environment.NewLine);

            List<RobotPlacment> robotPlacments = this.robotsEngine.Start(grid);

            return robotPlacments;
        }
    }
}
