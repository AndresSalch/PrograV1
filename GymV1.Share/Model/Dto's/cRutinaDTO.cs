using System.ComponentModel.DataAnnotations;

namespace GymV1.Share.Model
{
    public class cRutinaDTO
    {
        [Required]
        public String Nombre { get; set; } = string.Empty;
        [Required]
        public String Identificacion { get; set; } = string.Empty;
        [Required]
        public String Estado { get; set; } = string.Empty;
    }
}