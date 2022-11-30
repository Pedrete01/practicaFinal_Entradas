using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace practicaFinal_Entradas.Entities
{
    public class Categoria
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CategoriaId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? CategoriaDescrip { get; set; }
        public ICollection<Entrada> Entradas { get; set; } = new List<Entrada>();
    }
}
