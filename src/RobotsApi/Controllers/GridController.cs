using Microsoft.AspNetCore.Mvc;
using RobotsApi.InputModels;
using RobotsModel;
using RobotsParser.Abstract;
using RobotsService.Abstract;

namespace RobotsApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GridController : ControllerBase
    {
        private readonly IGridParser gridParser;
        private readonly IGridService gridService;

        public GridController(IGridParser gridParser, IGridService gridService)
        {
            this.gridParser = gridParser;
            this.gridService = gridService;
        }

        [HttpPost]
        public async Task<ActionResult<GridResponse>> SynchronizeGrid([FromBody] StringifiedGrid stringifiedGrid)
        {
            Grid grid = this.gridParser.Parse(stringifiedGrid.Grid, Environment.NewLine);

            GridResponse robotPlacments = await this.gridService.SynchronizeGrid(grid);

            return this.Ok(robotPlacments);
        }

        [HttpGet("{gridId}")]
        public async Task<ActionResult<GridResponse>> GetGrid(int gridId)
        {
            return this.Ok(await this.gridService.GetGrid(gridId));
        }
    }
}
