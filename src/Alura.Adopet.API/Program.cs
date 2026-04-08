using Alura.Adopet.API.Context;
using Alura.Adopet.API.Services;
using Microsoft.EntityFrameworkCore;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

builder.Logging.ClearProviders();
builder.Logging.AddConsole();

builder.Services.AddScoped<IEventoService, EventoService>()
.AddDbContext<AdopetContext>(opt =>
{
    opt.UseInMemoryDatabase("AdopetDB");
    opt.UseLoggerFactory(LoggerFactory.Create(builder => builder.AddSerilog()));
}
);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var serviceProvider = builder.Services.BuildServiceProvider();
var eventoService = serviceProvider.GetService<IEventoService>();

var app = builder.Build();
eventoService.GenerateFakeData();

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.MapControllers();
app.Run();