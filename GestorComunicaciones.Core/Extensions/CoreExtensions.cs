using GestorComunicaciones.Core.Interfaces;
using GestorComunicaciones.Core.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace GestorComunicaciones.Core.Extensions
{
    public static class CoreExtensions
    {
        public static void AddCore(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<IUserService, UserService>();
            serviceCollection.AddTransient<ICommunicationService,CommunicationService>();
        }
    }
}
