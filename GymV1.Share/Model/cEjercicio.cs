using System.ComponentModel.DataAnnotations;

namespace GymV1.Share.Model
{
    public class cEjercicio
    {
        [Key]
        public int idejercicio { get; set; } = 0;
        [Required]
        public int idcategoria { get; set; } = 0;
        [Required]
        public String descripcion { get; set; } = string.Empty;
    }
}
