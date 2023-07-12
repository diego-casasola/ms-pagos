using Domain.Pagos.Repositories;
using Infraestructure.Pagos.EF;
using Infraestructure.Pagos.EF.Context;
using Infraestructure.Pagos.EF.Repository;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Shared.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using MassTransit;
using Application.Pagos.UseCases.Consumers;
using Application.Pagos;

namespace Infraestructure.Pagos
{
    public static class Extensions
    {
        public static IServiceCollection AddInfrastrucutre(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddMediatR(configuration => configuration.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));
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

            AddRabbitMq(services, configuration);

            return services;
        }

        public static void AddRabbitMq(this IServiceCollection services, IConfiguration configuration)
        {
            var rabbitMqHost = configuration["RabbitMq:Host"];
            var rabbitMqPort = configuration["RabbitMq:Port"];
            var rabbitMqUserName = configuration["RabbitMq:UserName"];
            var rabbitMqPassword = configuration["RabbitMq:Password"];

            services.AddMassTransit(config =>
            {
                config.AddConsumer<DonacionCreadaConsumer>().Endpoint(endpoint => endpoint.Name = DonacionCreadaConsumer.QueueName);

                config.UsingRabbitMq((context, cfg) =>
                {
                    var uri = string.Format("amqps://{0}:{1}@{2}:{3}", rabbitMqUserName, rabbitMqPassword, rabbitMqHost, rabbitMqPort);
                    cfg.Host(uri);

                    cfg.ReceiveEndpoint(DonacionCreadaConsumer.QueueName, c =>
                    {
                        c.ConfigureConsumer<DonacionCreadaConsumer>(context);
                    });
                });
            });
        }
    }
}
