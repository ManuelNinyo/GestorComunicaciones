using Microsoft.OpenApi.Models;

using Microsoft.AspNetCore.Builder;

namespace GestorComunicaciones.WebApi.Extension
{
    /// <summary>
    /// class to configure starup 
    /// </summary>
    public static class ConfigureContainer
    {
        /// <summary>
        /// method that configure swagger into starup
        /// </summary>
        public static void UseSwaggerConfig(this IApplicationBuilder app)
        {
            app.UseSwagger();

            app.UseSwaggerUI(setupAction =>
            {
                setupAction.SwaggerEndpoint("/swagger/OpenAPISpecification/swagger.json", "Gestor de Communications");
                setupAction.RoutePrefix = string.Empty;
            });
        }
    }
}
