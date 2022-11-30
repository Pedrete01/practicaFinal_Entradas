using System;
using System.ComponentModel.DataAnnotations;
using System.Windows.Markup;

namespace practicaFinal_Entradas.ViewModels
{
    public class ContactoViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [MaxLength(50, ErrorMessage = "Subject demasiado largo")]
        public string Subject { get; set; }
        [Required]
        [MaxLength(255, ErrorMessage = "Mensaje demasiado largo")]
        public string Mensaje { get; set; }
        [Required]
        //[Range(typeof(bool), "true", "true", ErrorMessage = "No has aceptado los términos y condiciones.")]
        public bool Autorizar { get; set; }
    }
}
