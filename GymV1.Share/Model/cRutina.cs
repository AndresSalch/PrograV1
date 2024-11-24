using System.ComponentModel.DataAnnotations;

namespace GymV1.Share.Model
{
    public class cRutina
    {
        [Key]
        public int idrutina { get; set; } = 0;
        [Required]
        public String nombre { get; set; } = string.Empty;
        [Required]
        public String identificacion { get; set; } = string.Empty;
        [Required]
        public String estado { get; set; } = string.Empty;
    }
}
