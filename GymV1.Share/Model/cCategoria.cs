using System.ComponentModel.DataAnnotations;

namespace GymV1.Share.Model
{
    public class cCategoria
    {
        [Key]
        public int IdCategoria { get; set; } = 0;
        [Required]
        public String Categoria { get; set; } = string.Empty;
    }
}
