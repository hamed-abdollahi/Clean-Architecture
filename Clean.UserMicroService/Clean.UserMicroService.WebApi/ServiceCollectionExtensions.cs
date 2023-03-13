using Clean.Persistence;
using Clean.UserMicroService.Application.Interfaces;
using Clean.UserMicroService.Application.Services.Command.AddUser;
using Clean.UserMicroService.Application.Services.Command.UpdateUser;
using Clean.UserMicroService.Application.Services.Query.GetUser;
using MassTransit;
using Microsoft.EntityFrameworkCore;
using Clean.UserMicroService.Application.Services.Query.GetUsers;
using Clean.Shared.Models;

namespace Clean.PostMicroService.WebApi
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddMediatorServices(this IServiceCollection services)
        {
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(GetUsersQuery).Assembly));
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(GetUserQuery).Assembly));
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(AddUserCommand).Assembly));
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(UpdateUserCommand).Assembly));
            return services;
        }

        public static IServiceCollection AddServices(this IServiceCollection services, IConfiguration configuration)
        {
            var dbConnection = configuration.GetConnectionString("DefaultConnection");

            services.AddScoped<IGetUsersService, GetUsersService>();
            services.AddScoped<IGetUserService, GetUserService>();
            services.AddScoped<IAddUserService, AddUserService>();
            services.AddScoped<IUpdateUserService, UpdateUserService>();
            services.AddScoped<IApplicationDbContext, ApplicationDbContext>();

            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlServer(dbConnection);
            });

            return services;
        }

        public static IServiceCollection AddBus(this IServiceCollection services,IConfiguration configuration)
        {
            var rabbitMqSettings = configuration.GetSection(nameof(RabbitMqSettings)).Get<RabbitMqSettings>();
            services.AddMassTransit(mt => mt.AddBus(provider => Bus.Factory.CreateUsingRabbitMq(
                  config => config.Host(new Uri(rabbitMqSettings.Uri), h =>
                  {
                      h.Username(rabbitMqSettings.UserName);
                      h.Password(rabbitMqSettings.Password);
                  })
                ))
            );

            services.AddMassTransitHostedService();
            return services;
        }
    }
}
