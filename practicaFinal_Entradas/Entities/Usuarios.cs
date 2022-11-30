using Microsoft.AspNetCore.Identity;

namespace practicaFinal_Entradas.Entities
{
    public class Usuarios : IdentityUser
    {
        public string Nombre { get; set; } = string.Empty;
        public string Apellidos { get; set; } = string.Empty;
    }
}
