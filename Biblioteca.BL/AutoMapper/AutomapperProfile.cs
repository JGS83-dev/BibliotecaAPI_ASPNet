﻿using AutoMapper;
using Biblioteca.Entities.Models;
using Biblioteca.Entities.DTO;

namespace Biblioteca.BL.AutoMapper
{
    public class AutomapperProfile:Profile
    {
        public AutomapperProfile() {
            CreateMap<Autor, AutorDTO>()
                .ForMember(destination => destination.Codigo,options => options.MapFrom(source => source.Id))
                .ForMember(destination => destination.NombreAutor,options => options.MapFrom(source => source.Nombre))
                .ForMember(destination => destination.ApellidoAutor,options => options.MapFrom(source => source.Apellido))
                .ReverseMap();
        }
    }
}
