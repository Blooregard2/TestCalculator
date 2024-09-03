using FluentValidation;
using System.Runtime.CompilerServices;
using TextCalculator.Application.BusinessRules;
using TextCalculator.Application.Queries;

namespace Microsoft.Extensions.DependencyInjection;
///<summary>
///Inyeccion para la API
///</summary>
public static class DependencyInjection
{
    public static IServiceCollection AddWebServices(this IServiceCollection services)
    {
        services.AddScoped<IOperacionesQuery, OperacionesQuery>();
        services.AddScoped<OperacionesRules, OperacionesRules>();



        return services;
    }
}