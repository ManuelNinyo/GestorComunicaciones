using GestorComunicaciones.Core.Interfaces;
using GestorComunicaciones.Infrastructure.Data;
using GestorComunicaciones.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Configuration;

namespace GestorComunicaciones.Infrastructure
{
    public static class InfrastructureExtensions
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection serviceCollection, IConfiguration configuration)
        {
            serviceCollection.AddDbContext<CommunicationContext>(options =>
               options.UseSqlServer(configuration.GetConnectionString("Communications"))
           );
            serviceCollection.AddTransient<IUnitOfWork, UnitOfWork>();
            serviceCollection.AddEntityFrameworkSqlServer();

            return serviceCollection;
        }
    }
}
