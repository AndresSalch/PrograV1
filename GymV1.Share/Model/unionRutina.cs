using System.ComponentModel.DataAnnotations;

namespace GymV1.Share.Model
{
    public class unionRutina
    {
        [Required]
        public int idejercicio { get; set; } = 0;
        [Required]
        public int idcategoria { get; set; } = 0;
        [Required]
        public int idrutina { get; set; } = 0;
        [Required]
        public String nombre { get; set; } = string.Empty;
        [Required]
        public String descripcion { get; set; } = string.Empty;
        [Required]
        public String categoria { get; set; } = string.Empty;
        [Required]
        public String nombreRutina { get; set; } = string.Empty;
        [Required]
        public String identificacion { get; set; } = string.Empty;
        [Required]
        public String estado { get; set; } = string.Empty;
        [Required]
        public int cantidadseries { get; set; } = 0;
        [Required]
        public int repeticiones { get; set; } = 0;
        [Required]
        public String descripcionRutina { get; set; } = string.Empty;
    }
}
