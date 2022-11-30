using Microsoft.EntityFrameworkCore;
using practicaFinal_Entradas.DbConnection;
using practicaFinal_Entradas.Entities;

namespace practicaFinal_Entradas.Services
{
    public class CategoriaRepositorio : ICategoriaRepositorio
    {
        private readonly EntradasDbContext _entradasDbContext;

        public CategoriaRepositorio(EntradasDbContext entradasDbContext)
        {
            _entradasDbContext = entradasDbContext;
        }

        public async Task<bool> CategoriaExistsAsync(int id)
        {
            return await _entradasDbContext.Categorias.AnyAsync(c => c.CategoriaId == id);
        }

        public IEnumerable<Categoria> TodasCategorias(bool incluirEntradas)
        {
            Console.WriteLine(incluirEntradas);
            if (incluirEntradas)
            {
                Console.WriteLine("Entra");
                return _entradasDbContext.Categorias.Include(c => c.Entradas).ToList();
            }
            else
            {
                Console.WriteLine("Sale");
                return _entradasDbContext.Categorias.ToList();
            }
        }

        public Categoria? GetCategoriaById(int id)
        {
            return _entradasDbContext.Categorias.FirstOrDefault(c => c.CategoriaId == id);
        }

        public bool SaveAll()
        {
            return _entradasDbContext.SaveChanges() > 0;
        }

        public void AddCategoria(object model)
        {
            _entradasDbContext.Add(model);
        }
    }
}
