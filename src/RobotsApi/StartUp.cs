using Microsoft.AspNetCore.Diagnostics;
using Microsoft.EntityFrameworkCore;
using RobotsApi.Infrastructure;
using RobotsData;

namespace RobotsApi
{
    public class StartUp
    {
        public StartUp(IConfiguration configuration, IWebHostEnvironment environment)
        {
            this.Configuration = configuration;
            this.Environment = environment;
        }

        public IConfiguration Configuration { get; }
        public IWebHostEnvironment Environment { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<RobotsContext>(options =>
                 options.UseSqlServer(this.Configuration.GetConnectionString("RobotsDatabase"), x =>
                 {
                     x.EnableRetryOnFailure(6);
                 }));

            services.AddControllers();
            services.AddRouting();
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();

            services.InstallInfrastructure();
        }


        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            else
            {
                app.UseHsts();
            }

            app.UseRouting();

            app.UseEndpoints(
                endpoints =>
                {
                    endpoints.MapControllers();
                });
        }
    }
}
