using Clean.PostMicroService.WebApi;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddMediatorServices()
                .AddServices(builder.Configuration)
                .AddBus(builder.Configuration);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
