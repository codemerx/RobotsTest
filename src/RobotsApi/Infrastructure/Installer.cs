using RobotsParser.Abstract;
using RobotsParser.Parsers;
using RobotsService;
using RobotsService.Abstract;

namespace RobotsApi.Infrastructure
{
    internal static class InfrastructureInstaller
    {
        internal static void InstallInfrastructure(this IServiceCollection services)
        {
            services.AddScoped<IGridParser, GridParser>();
            services.AddScoped<IRobotParser, RobotParser>();
            services.AddScoped<IInstructionParser, InstructionParser>();
            services.AddScoped<IOrientationParser, OrientationParser>();
            services.AddScoped<IGridService, GridService>();
        }
    }
}
