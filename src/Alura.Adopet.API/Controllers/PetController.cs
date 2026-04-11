using Alura.Adopet.API.Context;
using Alura.Adopet.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Alura.Adopet.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PetController : ControllerBase
{
    [HttpGet("list")]
    public async Task<IResult> ListarPets()
    {
        var options = new DbContextOptionsBuilder<AdopetContext>()
               .UseInMemoryDatabase("AdopetDB")
               .Options;

        try
        {
            using AdopetContext context = new(options);
            var pets = await context.Pet.ToListAsync();

            return Results.Ok(pets);
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }

    [HttpPost("add")]
    public async Task<IResult> AdicionarPet(Pet pet)
    {
        IConfigurationRoot configuration = new ConfigurationBuilder()
               .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
               .AddJsonFile("appsettings.json")
               .Build();

        string _dataAtual = DateTime.Now.ToString("yyyy-MM-dd_HH");
        string? path = configuration["LoggerBasePath"] ?? "Logs";
        string? template = configuration["LoggerTemplate"] ?? "{Timestamp:yyyy-MM-dd HH:mm:ss} [{Level:u3}] {Message:lj}{NewLine}{Exception}";
        string fileName = Path.Combine(path, $"{_dataAtual}.adopet.log");

        var options = new DbContextOptionsBuilder<AdopetContext>()
               .UseInMemoryDatabase("AdopetDB")
               .Options;

        try
        {
            using AdopetContext context = new(options);
            await context.Pet.AddAsync(pet);
            await context.SaveChangesAsync();

            return Results.Ok("Pet adicionado com sucesso!");
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }
}