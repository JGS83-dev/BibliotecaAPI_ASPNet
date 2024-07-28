﻿using Biblioteca.BL.AutoMapper;
using Biblioteca.BL.Interfaces;
using Biblioteca.DAL.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Biblioteca.BL.Services
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddServiceConnector(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(AutomapperProfile).Assembly);
            services.AddTransient<IAutorService, AutorService>();
            services.AddTransient<IEditorialService, EditorialService>();
            services.AddTransient<ILibroService, LibroService>();
            services.AddRepositoryConnector();
            return services;
        }
    }
}
