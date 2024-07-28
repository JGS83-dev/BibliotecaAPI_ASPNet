using AutoMapper;
using Biblioteca.Entities.DTO;
using Biblioteca.Entities.Models;

namespace Biblioteca.BL.AutoMapper
{
    public class AutomapperProfile : Profile
    {
        public AutomapperProfile() 
        {
            CreateMap<Autor, AutorDTO>()
                .ForMember(destination => destination.Codigo, options => options.MapFrom(source => source.Id))
                .ForMember(destination => destination.NombreAutor, options => options.MapFrom(source => source.Nombre))
                .ForMember(destination => destination.ApellidoAutor, options => options.MapFrom(source => source.Apellido))
                .ReverseMap();

            CreateMap<Editorial, EditorialDto>()
                .ForMember(destination => destination.Codigo, options => options.MapFrom(source => source.id))
                .ForMember(destination => destination.NombreEditorial, options => options.MapFrom(source => source.Nombre))
                .ReverseMap();

            CreateMap<Libro, LibroDto>()
                .ForMember(destination => destination.Codigo, options => options.MapFrom(source => source.id))
                .ForMember(destination => destination.NombreLibro, options => options.MapFrom(source => source.Nombre))
                .ForMember(destination => destination.CodigoAutorLibro, options => options.MapFrom(source => source.CodigoAutor))
                .ForMember(destination => destination.CodigoEditorialLibro, options => options.MapFrom(source => source.CodigoEditorial))
                .ForMember(destination => destination.FechaLanzamientoLibro, options => options.MapFrom(source => source.FechaDeLanzamiento))
                .ReverseMap();
        }
    }
}
