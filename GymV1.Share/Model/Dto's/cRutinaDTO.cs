using System.ComponentModel.DataAnnotations;

namespace GymV1.Share.Model
{
    public class cRutinaDTO
    {
        [Required]
        public String nombre { get; set; } = string.Empty;
        [Required]
        public String identificacion { get; set; } = string.Empty;
        [Required]
        public String estado { get; set; } = "Pendiente";
    }
}