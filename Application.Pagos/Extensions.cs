using Domain.Pagos.Factories;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Application.Pagos
{
    public static class Extensions
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddMediatR(configuration => configuration.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));
            services.AddScoped<IPagoFactory, PagoFactory>();
            return services;
        }
    }
}