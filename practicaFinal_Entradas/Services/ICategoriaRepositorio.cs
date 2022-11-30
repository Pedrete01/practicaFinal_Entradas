using practicaFinal_Entradas.Entities;

namespace practicaFinal_Entradas.Services
{
    public interface ICategoriaRepositorio
    {
        Task<bool> CategoriaExistsAsync(int id);
        IEnumerable<Categoria> TodasCategorias(bool incluirEntradas);
        Categoria? GetCategoriaById(int entradaId);
        bool SaveAll();
        void AddCategoria(object model);
    }
}
