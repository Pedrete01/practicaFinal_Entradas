using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace practicaFinal_Entradas.ViewModels
{
    public class EntradaViewModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int entradaId { get; set; }
        [Required]
        public string entradaName { get; set; } = string.Empty;
        [Required]
        public string entradaDescripCorta { get; set; } = string.Empty;
        public string? entradaDescripLarga { get; set; }
        public decimal precio { get; set; }
        public string? imagen { get; set; }
        [Required]
        public string ubicacion { get; set; } = string.Empty;
        public string? ciudad { get; set; }
        public string? pais { get; set; }
        [Required]
        public string fecha { get; set; } = string.Empty;
        [Required]
        public int stock { get; set; }
        public int vendidas { get; set; }
        [Required]
        public int categoriaId { get; set; }
        public CategoriaViewModel categoria { get; set; } = default!;
    }
}
