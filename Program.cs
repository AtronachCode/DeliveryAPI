using System.Text.Json.Serialization;
using DeliveryAPI.Context;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddJsonOptions(options =>
                                    options.JsonSerializerOptions
                                        .ReferenceHandler = ReferenceHandler.IgnoreCycles);//Aqui estou resolvendo o problema de referencia ciclica com o JSON Serializer


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Obtendo a string de conexão do mySql
var mySqlConnection = builder.Configuration.GetConnectionString("DefaultConnection");

//Aqui estou incluindo a classe de contexto do EFcore no conteiner DI nativo 
//estou passando para o método AddDbContext qual é a classe de contexto e estou passando também o provedor
builder.Services.AddDbContext<DeliveryDbContext>(opt => opt.UseMySql(mySqlConnection,
    ServerVersion.AutoDetect(mySqlConnection)));

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
