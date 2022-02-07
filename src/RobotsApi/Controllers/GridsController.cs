using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RobotsApi.InputModels;
using RobotsModel;
using RobotsParser.Abstract;
using RobotsService.Abstract;

namespace RobotsApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GridsController : ControllerBase
    {
        private readonly IGridParser gridParser;
        private readonly IGridService gridService;
        private readonly ILogger<GridsController> logger;

        public GridsController(IGridParser gridParser, IGridService gridService, ILogger<GridsController> logger)
        {
            this.gridParser = gridParser;
            this.gridService = gridService;
            this.logger = logger;
        }

        [HttpPost]
        public async Task<ActionResult<GridResponse>> SynchronizeGrid([FromBody] StringifiedGridInput stringifiedGrid)
        {
            this.logger.LogInformation("Endpoint {Endpoint} invoked with parameters: {StringifiedGrid}", nameof(SynchronizeGrid), JsonConvert.SerializeObject(stringifiedGrid));

            GridInput grid = this.gridParser.Parse(stringifiedGrid.Input, Environment.NewLine);
            this.logger.LogInformation("At endpoint {Endpoint} successfully executed {MethodName}", nameof(SynchronizeGrid), nameof(this.gridParser.Parse));

            GridResponse robotPlacments = await this.gridService.SynchronizeGrid(grid);
            this.logger.LogInformation("At endpoint {Endpoint} successfully executed {MethodName}", nameof(SynchronizeGrid), nameof(this.gridService.SynchronizeGrid));

            return this.Ok(robotPlacments);
        }

        [HttpGet("{gridId}")]
        public async Task<ActionResult<GridResponse>> GetGrid(int gridId)
        {
            this.logger.LogInformation("Endpoint {Endpoint} invoked with grid id {GridId}", nameof(GetGrid), gridId);

            GridResponse gridResponse = await this.gridService.GetGrid(gridId);
            this.logger.LogInformation("At endpoint {Endpoint} successfully executed {MethodName}", nameof(GetGrid), nameof(this.gridService.GetGrid));

            return this.Ok(gridResponse);
        }
    }
}
