using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace API.Extentions
{
    public static class SwaggerServicesExtentions
    {
        public static IServiceCollection AddSwaggerDocumentation(this IServiceCollection swaggerServices){
            swaggerServices.AddSwaggerGen(c=>
                {
                    c.SwaggerDoc("v1", new OpenApiInfo{
                        Title="Ski Net API",
                        Version="v1"
                    });
                });

            return swaggerServices;
        }
        public static IApplicationBuilder UseSwaggerDocumentation(this IApplicationBuilder app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c=>{
                c.SwaggerEndpoint("/swagger/v1/swagger.json","SKINET API V1") ;  
            });
            return app;
        }
    }
}