using Alura.Adopet.API.Context;
using Alura.Adopet.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Serilog;

namespace Alura.Adopet.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ClienteController : ControllerBase
{
    [HttpGet("list")]
    public async Task<IResult> ListarClientes()
    {
        var options = new DbContextOptionsBuilder<AdopetContext>()
            .UseInMemoryDatabase("AdopetDB")
            .Options;

        try
        {
            using AdopetContext context = new(options);
            var clientes = await context.Cliente.ToListAsync();
            return Results.Ok(clientes);
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }

    [HttpPost("add")]
    public async Task<IResult> AdicionarCliente(Cliente cliente)
    {
        var options = new DbContextOptionsBuilder<AdopetContext>()
            .UseInMemoryDatabase("AdopetDB")
            .Options;

        try
        {
            using AdopetContext context = new(options);
            await context.Cliente.AddAsync(cliente);
            await context.SaveChangesAsync();

            Log.Information("Cliente cadastrado com sucesso!");

            return Results.Ok("Cliente cadastrado com sucesso!");
        }
        catch (Exception ex)
        {
            Log.Error("Erro ao cadastrar cliente: {Message}", ex.Message);
            return Results.Problem(ex.Message);
        }
    }
}