﻿using Biblioteca.BL.AutoMapper;
using Biblioteca.BL.Interfaces;
using Biblioteca.DAL.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.BL.Services
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddServiceConnector(this IServiceCollection services) { 
            services.AddAutoMapper(typeof(AutomapperProfile).Assembly);
            services.AddTransient<IAutorService, AutorService>();
            services.AddRepositoryConnector();
            return services;
        }
    }
}
