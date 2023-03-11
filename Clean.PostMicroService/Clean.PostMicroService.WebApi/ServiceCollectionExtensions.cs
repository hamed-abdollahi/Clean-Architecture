using Clean.Persistence;
using Clean.PostMicroService.Application.Interfaces;
using Clean.PostMicroService.Application.Services.Command.AddPost;
using Clean.PostMicroService.Application.Services.Command.AddUser;
using Clean.PostMicroService.Application.Services.Command.UpdatePost;
using Clean.PostMicroService.Application.Services.Command.UpdateUser;
using Clean.PostMicroService.Application.Services.Query.GetCompletePost;
using Clean.PostMicroService.Application.Services.Query.GetPost;
using Clean.PostMicroService.Application.Services.Query.GetPosts;
using Clean.PostMicroService.Application.Services.Query.GetUser;
using Clean.PostMicroService.WebApi.Models;
using MassTransit;
using Microsoft.EntityFrameworkCore;


namespace Clean.PostMicroService.WebApi
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddMediatorServices(this IServiceCollection services)
        {
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(GetPostsQuery).Assembly));
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(GetPostQuery).Assembly));
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(GetCompletePostQuery).Assembly));
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(AddPostCommand).Assembly));
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(UpdatePostCommand).Assembly));
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(AddUserCommand).Assembly));
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(UpdateUserCommand).Assembly));

            services.AddMediator(cfg =>
            {
                cfg.AddConsumer<ConsumerEndpoint>();
            });

            return services;
        }

        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<IGetPostsService, GetPostsService>();
            services.AddScoped<IGetPostService, GetPostService>();
            services.AddScoped<IGetCompletePostService, GetCompletePostService>();
            services.AddScoped<IAddPostService, AddPostService>();
            services.AddScoped<IUpdatePostService, UpdatePostService>();
            services.AddScoped<IAddUserService, AddUserService>();
            services.AddScoped<IGetUserService, GetUserService>();
            services.AddScoped<IUpdateUserService, UpdateUserService>();
            
            services.AddScoped<IApplicationDbContext, ApplicationDbContext>();
            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlServer("Data Source=.;Initial Catalog=Clean_PostService;Integrated Security=true;TrustServerCertificate=True");
            });


            return services;
        }

        public static IServiceCollection AddBus(this IServiceCollection services, RabbitMqSettings rabbitMqSettings)
        {
            services.AddMassTransit(x =>
            {      
                x.AddConsumer<ConsumerEndpoint>();
                x.UsingRabbitMq((context, config) =>
                {
                    config.Host(new Uri(rabbitMqSettings.Uri), h =>
                    {
                        h.Username(rabbitMqSettings.UserName);
                        h.Password(rabbitMqSettings.Password);
                    });
                    config.ReceiveEndpoint("add-user", e =>
                    {
                        e.Consumer<ConsumerEndpoint>(context);
                        e.DiscardSkippedMessages();
                    });
                    config.ReceiveEndpoint("update-user", e =>
                    {
                        e.Consumer<ConsumerEndpoint>(context);
                        e.DiscardSkippedMessages();
                    });
                });
            });

            services.AddMassTransitHostedService();
            return services;
        }
    }
}
