using Clean.PostMicroService.Application.Interfaces;
using Clean.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using Clean.PostMicroService.Application.Services.Query.GetPosts;
using Clean.PostMicroService.Application.Services.Query.GetPost;
using Clean.PostMicroService.Application.Services.Command.AddPost;
using Clean.PostMicroService.Application.Services.Command.UpdatePost;
using Clean.PostMicroService.WebApi.Models;
using MassTransit;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var rabbitMqSettings = builder.Configuration.GetSection(nameof(RabbitMqSettings)).Get<RabbitMqSettings>();
builder.Services.AddMassTransit(x => x.UsingRabbitMq((context, config) =>
{
    config.Host(new Uri(rabbitMqSettings.Uri), h =>
    {
        h.Username(rabbitMqSettings.UserName);
        h.Password(rabbitMqSettings.Password);
    });
    config.ReceiveEndpoint("user", e =>
    {
        e.Consumer<ConsumerClass>(context);
    });
    x.AddConsumer<ConsumerClass>();
}));

builder.Services.AddScoped<IGetPostsService, GetPostsService>();
builder.Services.AddScoped<IGetPostService, GetPostService>();
builder.Services.AddScoped<IAddPostService, AddPostService>();
builder.Services.AddScoped<IUpdatePostService, UpdatePostService>();


builder.Services.AddScoped<IApplicationDbContext, ApplicationDbContext>();
builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlServer("Data Source=.;Initial Catalog=Clean_PostService;Integrated Security=true;TrustServerCertificate=True");
});

//builder.Services.AddMediatR(typeof(GetUsersQuery).Assembly);
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(GetPostsQuery).Assembly));
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(GetPostQuery).Assembly));
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(AddPostCommand).Assembly));
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(UpdatePostCommand).Assembly));


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
