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

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var eventoService = scope.ServiceProvider.GetRequiredService<IEventoService>();
    eventoService.GenerateFakeData();
}

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.MapControllers();
app.Run();