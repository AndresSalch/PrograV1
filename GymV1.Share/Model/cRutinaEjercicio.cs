using System.ComponentModel.DataAnnotations;

namespace GymV1.Share.Model
{
    public class cRutinaEjercicio
    {
        [Key]
        public int IdRutina { get; set; } = 0;
        [Key]
        public int IdEjercicio { get; set; } = 0;
        [Required]
        public int CantidadSeries { get; set; } = 0;
        [Required]
        public int Repeticiones { get; set; } = 0;
        [Required]
        public String Descripcion { get; set; } = string.Empty;
    }
}
