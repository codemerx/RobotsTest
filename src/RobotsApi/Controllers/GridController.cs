using Microsoft.AspNetCore.Mvc;
using RobotsApi.InputModels;
using RobotsModel;
using RobotsParser.Abstract;
using RobotsService.Abstract;
using RobotsService.Models;

namespace RobotsApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GridController : ControllerBase
    {
        private readonly IGridParser gridParser;
        private readonly IGridService robotsEngine;

        public GridController(IGridParser gridParser, IGridService robotsEngine)
        {
            this.gridParser = gridParser;
            this.robotsEngine = robotsEngine;
        }

        [HttpPost]
        public async Task<ActionResult<List<RobotPlacement>>> Post([FromBody] StringifiedGrid stringifiedGrid)
        {
            Grid grid = this.gridParser.Parse(stringifiedGrid.Grid, Environment.NewLine);

            List<RobotPlacement> robotPlacments = await this.robotsEngine.SynchronizeGrid(grid);

            return this.Ok(robotPlacments);
        }
    }
}
