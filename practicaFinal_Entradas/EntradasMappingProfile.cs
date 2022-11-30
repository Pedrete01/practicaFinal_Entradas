using AutoMapper;
using practicaFinal_Entradas.Entities;
using practicaFinal_Entradas.ViewModels;

namespace practicaFinal_Entradas
{
    public class EntradasMappingProfile : Profile
    {
        public EntradasMappingProfile()
        {
            CreateMap<Entrada, EntradaViewModel>()
                .ForMember(e => e.entradaId, ex => ex.MapFrom(e => e.entradaId))
                .ReverseMap();

            CreateMap<Categoria, CategoriaViewModel>()
                .ForMember(c => c.CategoriaId, ex => ex.MapFrom(c => c.CategoriaId))
                .ReverseMap();
        }
    }
}
