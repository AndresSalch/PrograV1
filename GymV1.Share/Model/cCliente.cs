using System.ComponentModel.DataAnnotations;

namespace GymV1.Share.Model
{
    public class cCliente
    {
        [Required]
        public String nombre { get; set; } = string.Empty;
        [Key]
        public String identificacion { get; set; } = string.Empty;
        [Required]
        public DateTime fechanacimiento { get; set; } = DateTime.Now;
        [Required]
        public decimal estatura { get; set; } = decimal.Zero;
        [Required]
        public decimal imc { get; set; } = decimal.Zero;
        [Required]
        public decimal peso { get; set; } = decimal.Zero;
        [Required]
        public String correo { get; set; } = string.Empty;
    }
}
