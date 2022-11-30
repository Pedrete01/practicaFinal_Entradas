using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using practicaFinal_Entradas.Entities;
using practicaFinal_Entradas.Services;
using practicaFinal_Entradas.ViewModels;

namespace practicaFinal_Entradas.Controllers
{
    [Route("api/Categoria/{CategoriaId}/Entradas")]
    public class EntradaListController : Controller
    {
        private readonly IEntradaRepositorio _entradaRepositorio;
        private readonly ICategoriaRepositorio _categoriaRepositorio;
        private readonly ILogger<EntradaListController> _logger;
        private readonly IMapper _mapper;

        public EntradaListController(IEntradaRepositorio entradaRepositorio, ICategoriaRepositorio categoriaRepositorio, ILogger<EntradaListController> logger, IMapper mapper)
        {
            _entradaRepositorio = entradaRepositorio;
            _categoriaRepositorio = categoriaRepositorio;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult Get(int CategoriaId)
        {
            var categoria = _categoriaRepositorio.GetCategoriaById(CategoriaId);
            if (categoria != null) 
            {
                var result = _mapper.Map<ICollection<Entrada>, ICollection<EntradaViewModel>>(categoria.Entradas);
                return Ok(result); 
            }

            return NotFound();

        }

        [HttpGet("{id}")]
        public IActionResult Get(int CategoriaId, int id)
        {
            var categoria = _categoriaRepositorio.GetCategoriaById(CategoriaId);
            if(categoria != null)
            {
                var entrada = categoria.Entradas.Where(i => i.entradaId == id).FirstOrDefault();
                if (entrada != null)
                {
                    var result = _mapper.Map<Entrada, EntradaViewModel>(entrada);
                    return Ok(result);
                }
            }

            return NotFound();
        }

    }
}