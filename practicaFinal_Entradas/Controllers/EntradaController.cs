using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using practicaFinal_Entradas.Entities;
using practicaFinal_Entradas.Services;
using practicaFinal_Entradas.ViewModels;

namespace practicaFinal_Entradas.Controllers
{
    [ApiController]
    //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Produces("application/json")]
    public class EntradaController : Controller
    {
        private readonly IEntradaRepositorio _entradaRepositorio;
        private readonly ICategoriaRepositorio _categoriaRepositorio;
        private readonly ILogger<EntradaController> _logger;
        private readonly IMapper _mapper;

        public EntradaController(IEntradaRepositorio entradaRepositorio, ICategoriaRepositorio categoriaRepositorio, ILogger<EntradaController> logger, IMapper mapper)
        {
            _entradaRepositorio = entradaRepositorio;
            _categoriaRepositorio = categoriaRepositorio;
            _logger = logger;
            _mapper = mapper;
        }


        [HttpGet]
        [Route("api/[Controller]")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public ActionResult<IEnumerable<Entrada>> Get()
        {
            try
            {
                var result = _entradaRepositorio.TodasEntradas;
                return Ok(_mapper.Map<IEnumerable<EntradaViewModel>>(result));
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al obtener entradas: {ex}");
                return BadRequest("Error al obtener entradas.");
            }
        }

        [HttpGet]
        [Route("api/[Controller]/Destacadas")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public ActionResult<IEnumerable<Entrada>> GetDestacada()
        {
            Console.WriteLine("Hola");
            try
            {
                var result = _entradaRepositorio.EntradasMasVendidas;
                return Ok(_mapper.Map<IEnumerable<EntradaViewModel>>(result));
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al obtener entradas: {ex}");
                return BadRequest("Error al obtener entradas.");
            }
        }

        //public IActionResult List()
        //{
        //    EntradaListViewModel entradaListViewModel = new EntradaListViewModel(_entradaRepositorio.TodasEntradas, "Entradas");
        //    return View(entradaListViewModel);
        //}
        
        [HttpGet]
        [Route("api/[Controller]/{id:int}")]
        public IActionResult Get(int id)
        {
            try
            {
                var entrada = _entradaRepositorio.GetEntradaById(id);
                if (entrada == null)
                {
                    return NotFound();
                }
                return Ok(_mapper.Map<Entrada, EntradaViewModel>(entrada));
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al obtener entrada: {ex}");
                return BadRequest("Error al obtener entrada.");
            }
        }
        
        [HttpPost]
        [Route("api/[Controller]")]
        public IActionResult Post([FromBody]EntradaViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var nuevaEntrada = _mapper.Map<EntradaViewModel, Entrada>(model);
                    
                    _entradaRepositorio.AddEntrada(nuevaEntrada);
                    if (_entradaRepositorio.SaveAll())
                    {
                        return Created($"/api/Categoria/{nuevaEntrada.categoriaId}/Entrada/{nuevaEntrada.entradaId}", _mapper.Map<Entrada, EntradaViewModel>(nuevaEntrada));
                    }
                }
                else
                {
                    return BadRequest(ModelState);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al guardar entrada: {ex}");
            }

            return BadRequest("Error al crear entrada");
        }

        [HttpPut]
        [Route("api/[Controller]/{id:int}")]
        public IActionResult UpdateEntrada(int id,
            Entrada entrada)
        {
            try
            {
                var entradaEntity = _entradaRepositorio.GetEntradaById(id);
                if (entradaEntity == null)
                {
                    return NotFound();
                }

                _mapper.Map(entrada, entradaEntity);
                _entradaRepositorio.UpdateEntrada(entradaEntity);
                _entradaRepositorio.SaveAll();

                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al actualizar entrada: {ex}");
                return BadRequest("Error al actualizar entrada.");
            }
        }

        [HttpPatch]
        [Route("api/[Controller]/{id:int}")]
        public IActionResult PartiallyUpdateEntrada(
            int id,
            JsonPatchDocument<Entrada> patchDocument)
        {

            var entradaEntity = _entradaRepositorio.GetEntradaById(id);
            if (entradaEntity == null)
            {
                return NotFound();
            }

            var entradaToPatch = _mapper.Map<Entrada>(
                entradaEntity);

            patchDocument.ApplyTo(entradaToPatch, ModelState);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (!TryValidateModel(entradaToPatch))
            {
                return BadRequest(ModelState);
            }

            _mapper.Map(entradaToPatch, entradaEntity);
            _entradaRepositorio.SaveAll();

            return NoContent();
        }

        //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpDelete]
        [Route("api/[Controller]/{id:int}")]
        public IActionResult DeleteEntrada(
            int id)
        {
            try
            {
                if (this.User.Identity.IsAuthenticated)
                {
                    var entrada = _entradaRepositorio.GetEntradaById(id);
                    if (entrada == null)
                    {
                        return NotFound();
                    }
                    _entradaRepositorio.DeleteEntrada(entrada);
                    _entradaRepositorio.SaveAll();

                    return Ok();
                }
                return BadRequest("Usuario no logueado.");
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al eliminar entrada: {ex}");
                return BadRequest("Error al eliminar entrada.");
            }
        }
    }
}
