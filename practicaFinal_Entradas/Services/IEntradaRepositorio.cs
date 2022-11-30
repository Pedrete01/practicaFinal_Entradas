using practicaFinal_Entradas.Entities;

namespace practicaFinal_Entradas.Services
{
    public interface IEntradaRepositorio
    {
        IEnumerable<Entrada> TodasEntradas { get; }
        IEnumerable<Entrada> EntradasMasVendidas { get; }
        Entrada? GetEntradaById(int entradaId);
        Task<bool> EntradaExistsAsync(int id);
        void DeleteEntrada(Entrada entrada);
        void UpdateEntrada(Entrada entrada);
        bool SaveAll();
        void AddEntrada(object model);
    }
}
