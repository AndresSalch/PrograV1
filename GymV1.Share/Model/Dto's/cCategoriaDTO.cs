using System.ComponentModel.DataAnnotations;

namespace GymV1.Share.Model
{
    public class cCategoriaDTO
    {
        [Required]
        public String categoria { get; set; } = string.Empty;
    }
}
