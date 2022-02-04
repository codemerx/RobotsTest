using System.ComponentModel.DataAnnotations;

namespace RobotsApi.InputModels
{
    public class StringifiedGridInput
    {
        [Required]
        public string Input { get; set; } = null!;
    }
}
