using System.ComponentModel.DataAnnotations;

namespace Gomoku.Contracts.Inputs
{
    public class PlayerInput
    {
        [Required]
        public string Name { get; set; } = string.Empty;
    }
}