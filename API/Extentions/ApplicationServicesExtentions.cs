using System.Linq;
using API.Errors;
using Core.Interfaces;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace API.Extentions
{
    public static class ApplicationServicesExtentions
    {
        public static IServiceCollection AddAplicationServices (this IServiceCollection services)
        {
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IBasketRepository, BasketRepository>();
            services.AddScoped(typeof(IGenericRepository<>),typeof(GenericRepository<>));
            services.Configure<ApiBehaviorOptions>(options =>{
                    options.InvalidModelStateResponseFactory = actionContext =>{
                        var errors = actionContext.ModelState.Where(e =>e.Value.Errors.Count>0)
                        .SelectMany(x =>x.Value.Errors)
                        .Select(x=>x.ErrorMessage).ToArray();
                        var errorResponse = new ApiValidationErrorResponse {
                            Errors = errors
                        };
                        return new BadRequestObjectResult(errorResponse);
                    };
                });
                return services;
        }
    }
}