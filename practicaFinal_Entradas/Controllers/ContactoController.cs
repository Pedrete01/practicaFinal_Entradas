using Microsoft.AspNetCore.Mvc;
using practicaFinal_Entradas.Services;
using practicaFinal_Entradas.ViewModels;

namespace practicaFinal_Entradas.Controllers
{
    public class ContactoController : Controller
    {
        private readonly IMailService _mailService;

        public ContactoController(IMailService mailService)
        {
            _mailService = mailService;
        }

        [HttpGet("contacto")]
        public IActionResult Contacto()
        {
            return View();
        }

        [HttpPost("contacto")]
        public IActionResult Contacto(ContactoViewModel model)
        {
            if (ModelState.IsValid)
            {
                // Enviar email
                _mailService.EnviarMensaje("pedrete01@gmail.com", model.Subject, model.Mensaje);
                ViewBag.Mensaje = "Mensaje enviado";
                ModelState.Clear();
            }

            return View();
        }
    }
}
