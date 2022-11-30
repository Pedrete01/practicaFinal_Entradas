using practicaFinal_Entradas.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace practicaFinal_Entradas.ViewModels
{
    public class CategoriaViewModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CategoriaId { get; set; }
        [Required]
        public string Name { get; set; } = string.Empty;
        public string? CategoriaDescrip { get; set; }
        public ICollection<EntradaViewModel> Entradas { get; set; } = new List<EntradaViewModel>();
    }
}
