using Microsoft.EntityFrameworkCore;
using RobotsData.Models;

namespace RobotsData
{
    public class RobotsContext : DbContext
    {
        public RobotsContext(DbContextOptions<RobotsContext> options) : base(options)
        {

        }

        public DbSet<Grid> Grids { get; set; } = null!;

        public DbSet<Robot> Robots { get; set; } = null!;
    }
}