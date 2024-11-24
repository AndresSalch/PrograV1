using System.ComponentModel.DataAnnotations;

namespace GymV1.Share.Model
{
    public class cCliente
    {
        [Required]
        public String Nombre { get; set; } = string.Empty;
        [Key]
        public String Identificacion { get; set; } = string.Empty;
        [Required]
        public DateTime FechaNacimiento { get; set; } = DateTime.Now;
        [Required]
        public decimal Estatura { get; set; } = decimal.Zero;
        [Required]
        public decimal IMC { get; set; } = decimal.Zero;
        [Required]
        public decimal Peso { get; set; } = decimal.Zero;
        [Required]
        public String Correo { get; set; } = string.Empty;
    }
}
