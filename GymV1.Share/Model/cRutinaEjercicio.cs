using System.ComponentModel.DataAnnotations;

namespace GymV1.Share.Model
{
    public class cRutinaEjercicio
    {
        [Key]
        public int idrutina { get; set; } = 0;
        [Key]
        public int idejercicio { get; set; } = 0;
        [Required]
        public int cantidadseries { get; set; } = 0;
        [Required]
        public int repeticiones { get; set; } = 0;
        [Required]
        public String descripcion { get; set; } = string.Empty;
    }
}
