using System.ComponentModel.DataAnnotations;

namespace RobotsApi.Models
{
    public class StringifiedGrid
    {
        [Required]
        public string Grid { get; set; } = null!;
    }
}
