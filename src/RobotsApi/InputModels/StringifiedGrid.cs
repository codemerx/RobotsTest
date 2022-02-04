using System.ComponentModel.DataAnnotations;

namespace RobotsApi.InputModels
{
    public class StringifiedGrid
    {
        [Required]
        public string Grid { get; set; } = null!;
    }
}
