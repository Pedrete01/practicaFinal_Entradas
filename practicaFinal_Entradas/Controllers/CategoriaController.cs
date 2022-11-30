using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using practicaFinal_Entradas.Entities;
using practicaFinal_Entradas.Services;
using practicaFinal_Entradas.ViewModels;

namespace practicaFinal_Entradas.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    //[Authorize(AuthenticationSchemes=JwtBearerDefaults.AuthenticationScheme)]
    [Produces("application/json")]
    public class CategoriaController : Controller
    {
        private readonly IEntradaRepositorio _entradaRepositorio;
        private readonly ICategoriaRepositorio _categoriaRepositorio;
        private readonly ILogger<EntradaController> _logger;
        private readonly IMapper _mapper;

        public CategoriaController(IEntradaRepositorio entradaRepositorio, ICategoriaRepositorio categoriaRepositorio, ILogger<EntradaController> logger, IMapper mapper)
        {
            _entradaRepositorio = entradaRepositorio;
            _categoriaRepositorio = categoriaRepositorio;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public ActionResult<IEnumerable<Entrada>> Get(bool incluirEntradas = true)
        {
            try
            {
                var result = _categoriaRepositorio.TodasCategorias(incluirEntradas);
                return Ok(_mapper.Map<IEnumerable<CategoriaViewModel>>(result));
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al obtener categorías: {ex}");
                return BadRequest("Error al obtener categoría.");
            }
        }

        //public IActionResult List()
        //{
        //    EntradaListViewModel entradaListViewModel = new EntradaListViewModel(_entradaRepositorio.TodasEntradas, "Entradas");
        //    return View(entradaListViewModel);
        //}

        [HttpGet("{id:int}")]
        public IActionResult Get(int id)
        {
            try
            {
                var categoria = _categoriaRepositorio.GetCategoriaById(id);
                if (categoria == null)
                {
                    return NotFound();
                }
                return Ok(_mapper.Map<Categoria, CategoriaViewModel>(categoria));
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al obtener entrada: {ex}");
                return BadRequest("Error al obtener entrada.");
            }
        }

        [HttpPost]
        public IActionResult Post([FromBody]CategoriaViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var nuevaCategoria = _mapper.Map<CategoriaViewModel, Categoria>(model);

                    _categoriaRepositorio.AddCategoria(nuevaCategoria);
                    if (_categoriaRepositorio.SaveAll())
                    {
                        return Created($"/api/Entrada/{nuevaCategoria.CategoriaId}", _mapper.Map<Categoria, CategoriaViewModel>(nuevaCategoria));
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
    }
}
