using Microsoft.Extensions.DependencyInjection;
using RobotsParser.Abstract;
using RobotsParser.Parsers;

namespace RobotsTest
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<IGridParser, GridParser>();
            services.AddTransient<IRobotParser, RobotParser>();
            services.AddTransient<IInstructionParser, InstructionParser>();
            services.AddTransient<IOrientationParser, OrientationParser>();
        }
    }
}
