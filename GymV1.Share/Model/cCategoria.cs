using System.ComponentModel.DataAnnotations;

namespace GymV1.Share.Model
{
    public class cCategoria
    {
        [Key]
        public int idcategoria { get; set; } = 0;
        [Required]
        public String categoria { get; set; } = string.Empty;
    }
}
