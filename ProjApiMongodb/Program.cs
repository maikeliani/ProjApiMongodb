using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using ProjApiMongodb.Config;
using ProjApiMongodb.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//configuration Singleton  andd AppSettings Parameters
builder.Services.Configure<ProjMdSettings>(builder.Configuration.GetSection("ProjMdSettings"));//ESSA LINHA E A DEBAIXO PERMITE ENXERGAR O ARQUIVO DE CONFIGURAÇÃO E PEGAR AS ALTERAÇÕES FEITAS
builder.Services.AddSingleton<IProjMdSettings>(s => s.GetRequiredService<IOptions<ProjMdSettings>>().Value);
builder.Services.AddSingleton<ClientService>(); //    <- permite a injecao de dependencia e usar o Singleton.... de acordo q for criando os services vai add linhas igual a essa!!! tipo AdressService



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
