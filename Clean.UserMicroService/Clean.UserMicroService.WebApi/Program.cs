using Clean.UserMicroService.Application.Interfaces;
using Clean.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using Clean.UserMicroService.Application.Services.Query.GetUsers;
using Clean.UserMicroService.Application.Services.Query.GetUser;
using Clean.UserMicroService.Application.Services.Command.AddUser;
using Clean.UserMicroService.Application.Services.Command.UpdateUser;
using MassTransit;
using Clean.UserMicroService.WebApi.Models;

var builder = WebApplication.CreateBuilder(args);

var rabbitMqSettings = builder.Configuration.GetSection(nameof(RabbitMqSettings)).Get<RabbitMqSettings>();
builder.Services.AddMassTransit(mt => mt.AddBus(provider => Bus.Factory.CreateUsingRabbitMq(
      config => config.Host(new Uri(rabbitMqSettings.Uri), h =>
      {
          h.Username(rabbitMqSettings.UserName);
          h.Password(rabbitMqSettings.Password);
      })

    ))
);

builder.Services.AddMassTransitHostedService();

builder.Services.AddScoped<IGetUsersService, GetUsersService>();
builder.Services.AddScoped<IGetUserService, GetUserService>();
builder.Services.AddScoped<IAddUserService, AddUserService>();
builder.Services.AddScoped<IUpdateUserService, UpdateUserService>();


builder.Services.AddScoped<IApplicationDbContext, ApplicationDbContext>();
builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlServer("Data Source=.;Initial Catalog=Clean_UserService;Integrated Security=true;TrustServerCertificate=True");
});

//builder.Services.AddMediatR(typeof(GetUsersQuery).Assembly);
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(GetUsersQuery).Assembly));
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(GetUserQuery).Assembly));
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(AddUserCommand).Assembly));
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(UpdateUserCommand).Assembly));


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
