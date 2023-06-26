using Application.Ventas;
using Domain.Pagos.Repositories;
using Infraestructure.Pagos.EF;
using Infraestructure.Pagos.EF.Context;
using Infraestructure.Pagos.EF.Repository;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ShareKernel.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Pagos
{
    public static class Extensions
    {
        public static IServiceCollection AddInfrastrucutre(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddApplication();
            services.AddDbContext<ReadDbContext>(options =>
            {
                options.UseNpgsql(configuration.GetConnectionString("ConectionPagosDB"));
            });
            services.AddDbContext<WriteDbContext>(options =>
            {
                options.UseNpgsql(configuration.GetConnectionString("ConectionPagosDB"));
            });

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IPagoRepository, PagoRepository>();

            return services;
        }

        public static bool Contains(this string source, string toCheck, StringComparison comp)
        {
            return source?.IndexOf(toCheck, comp) >= 0;
        }
    }
}
