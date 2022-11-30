using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using practicaFinal_Entradas.Entities;

namespace practicaFinal_Entradas.DbConnection
{
    public class EntradasDbContext : IdentityDbContext<Usuarios>
    {
        public EntradasDbContext(DbContextOptions<EntradasDbContext> options) : base(options)
        {
        }

        public DbSet<Categoria> Categorias { get; set; }

        public DbSet<Entrada> Entradas { get; set; }
    }
}
