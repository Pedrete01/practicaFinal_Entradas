using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using practicaFinal_Entradas.Entities;
using practicaFinal_Entradas.ViewModels;

namespace practicaFinal_Entradas.Controllers
{
    [ApiController]
    [Produces("application/json")]
    public class RegistroController : Controller
    {
        private readonly UserManager<Usuarios> _userManager;

        public RegistroController(
            UserManager<Usuarios> userManager)
        {
            _userManager = userManager;
        }

        [Route("api/Registro")]
        [HttpPost]
        public async Task<IActionResult> Registro(RegisterViewModel model)
        {
            Console.WriteLine(model);
            if (ModelState.IsValid)
            {
                Usuarios usuario = await _userManager.FindByEmailAsync(model.Email);

                if (usuario == null)
                {
                    usuario = new Usuarios()
                    {
                        Email = model.Email,
                        UserName = model.Username
                    };

                    var result = await _userManager.CreateAsync(usuario, model.Password);
                    if (result != IdentityResult.Success)
                    {
                        Console.WriteLine(result);
                        throw new InvalidOperationException("No se ha podido registrar al usuario");
                    }
                    else
                    {
                        return RedirectToAction("Index", "Home");
                    }
                }
            }
            ModelState.AddModelError("", "Error al crear usuario");

            return View();
        }
    }
}
