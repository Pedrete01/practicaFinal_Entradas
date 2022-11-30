using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace practicaFinal_Entradas.Entities
{
    public class Entrada
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int entradaId { get; set; }
        public string entradaName { get; set; } = string.Empty;
        public string entradaDescripCorta { get; set; } = string.Empty;
        public string? entradaDescripLarga { get; set; }
        public decimal precio { get; set; }
        public string? imagen { get; set; }
        public string ubicacion { get; set; } = string.Empty;
        public string? ciudad { get; set; }
        public string? pais { get; set; }
        public string fecha { get; set; } = string.Empty;
        public int stock { get; set; }
        public int vendidas { get; set; }
        public int categoriaId { get; set; }
        public Categoria? categoria { get; set; }
    }
}
