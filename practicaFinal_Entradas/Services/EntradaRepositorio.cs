using Microsoft.EntityFrameworkCore;
using practicaFinal_Entradas.DbConnection;
using practicaFinal_Entradas.Entities;

namespace practicaFinal_Entradas.Services
{
    public class EntradaRepositorio : IEntradaRepositorio
    {
        private readonly EntradasDbContext _entradasDbContext;

        public EntradaRepositorio(EntradasDbContext entradasDbContext)
        {
            _entradasDbContext = entradasDbContext;
        }

        public IEnumerable<Entrada> TodasEntradas
        {
            get {
                return _entradasDbContext.Entradas.Include(c => c.categoria); 
            }
        }

        public IEnumerable<Entrada> EntradasMasVendidas
        {
            get
            {
                return _entradasDbContext.Entradas.Include(c => c.categoria).Where(e => e.vendidas > 500);
            }
        }

        public Entrada? GetEntradaById(int id)
        {
            return _entradasDbContext.Entradas.FirstOrDefault(e => e.entradaId == id);
        }
        public async Task<bool> EntradaExistsAsync(int id)
        {
            return await _entradasDbContext.Entradas.AnyAsync(e => e.entradaId == id);
        }

        public void DeleteEntrada(Entrada entrada)
        {
            _entradasDbContext.Entradas.Remove(entrada);
        }

        public void UpdateEntrada(Entrada entrada)
        {
            _entradasDbContext.Entradas.Update(entrada);
        }

        public bool SaveAll()
        {
            return _entradasDbContext.SaveChanges() > 0;
        }

        public void AddEntrada(object model)
        {
            _entradasDbContext.Add(model);
        }
    }
}
