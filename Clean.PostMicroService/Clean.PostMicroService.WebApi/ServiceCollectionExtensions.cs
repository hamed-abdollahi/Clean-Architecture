using Clean.Persistence;
using Clean.PostMicroService.Application.BackgroundWorker.AddPost;
using Clean.PostMicroService.Application.BackgroundWorker.AddUser;
using Clean.PostMicroService.Application.Interfaces;
using Clean.PostMicroService.Application.Services.Command.AddPost;
using Clean.PostMicroService.Application.Services.Command.AddUser;
using Clean.PostMicroService.Application.Services.Command.UpdatePost;
using Clean.PostMicroService.Application.Services.Command.UpdateUser;
using Clean.PostMicroService.Application.Services.Query.GetCompletePost;
using Clean.PostMicroService.Application.Services.Query.GetPost;
using Clean.PostMicroService.Application.Services.Query.GetPosts;
using Clean.PostMicroService.Application.Services.Query.GetUser;
using Clean.Shared.BaseChannel;
using Clean.Shared.Models;
using Clean.UserMicroService.Application.Services.Command.AddUser;
using MassTransit;
using Microsoft.EntityFrameworkCore;
using MongoDB.Driver;

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

        public static IServiceCollection AddServices(this IServiceCollection services,IConfiguration configuration)
        {
            var dbConnection = configuration.GetConnectionString("DefaultConnection");
            var mongoDbSettings = configuration.GetSection(nameof(MongoDbSettings)).Get<MongoDbSettings>();


            services.AddScoped<IGetPostsService, GetPostsService>();
            services.AddScoped<IGetPostService, GetPostService>();
            services.AddScoped<IGetCompletePostService, GetCompletePostService>();
            services.AddScoped<IAddPostService, AddPostService>();
            services.AddScoped<IUpdatePostService, UpdatePostService>();
            services.AddScoped<IAddUserService, AddUserService>();
            services.AddScoped<IGetUserService, GetUserService>();
            services.AddScoped<IUpdateUserService, UpdateUserService>();
            services.AddScoped<GetUserService>();
            services.AddScoped<AddUserMongoService>();
            services.AddScoped<GetPostService>();
            services.AddScoped<AddPostMongoService>();

            services.AddScoped<IApplicationDbContext, ApplicationDbContext>();
            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlServer(dbConnection);
            });

            var mongoClient = new MongoClient(mongoDbSettings.Uri);
            var mongoDatabase = mongoClient.GetDatabase(mongoDbSettings.Database);
            services.AddSingleton(mongoDatabase);

            services.AddSingleton(typeof(ChannelQueue<>));
            services.AddHostedService<AddUserWorker>();
            services.AddHostedService<AddPostWorker>();

            return services;
        }

        public static IServiceCollection AddBus(this IServiceCollection services, IConfiguration configuration)
        {
            var rabbitMqSettings = configuration.GetSection(nameof(RabbitMqSettings)).Get<RabbitMqSettings>();
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
