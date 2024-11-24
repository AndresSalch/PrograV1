using System.ComponentModel.DataAnnotations;

namespace GymV1.Share.Model
{
    public class cCategoriaDTO
    {
        [Required]
        public String Categoria { get; set; } = string.Empty;
    }
}
