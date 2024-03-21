using Microsoft.Extensions.Options;
using ProducerFiap.Config;
using ProducerFiap.ExternalServices;
using ProducerFiap.ExternalServices.Interfaces;
using ProducerFiap.Services;
using ProducerFiap.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.Configure<MQConfig>(builder.Configuration.GetSection("MQ"));

builder.Services.AddScoped<IConnectionFactoryMQ, ConnectionFactoryMQ>();
builder.Services.AddScoped<IUserService, UserService>();

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

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

