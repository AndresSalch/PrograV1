using System.ComponentModel.DataAnnotations;

namespace GymV1.Share.Model
{
    public class cEjercicio
    {
        [Key]
        public int IdEjercicio { get; set; } = 0;
        [Required]
        public int IdCategoria { get; set; } = 0;
        [Required]
        public String Descripcion { get; set; } = string.Empty;
    }
}
