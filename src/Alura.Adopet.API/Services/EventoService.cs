using System;
using Alura.Adopet.API.Context;
using Alura.Adopet.Domain.Entities;

namespace Alura.Adopet.API.Services;

public class EventoService : IEventoService
{
    private readonly AdopetContext _context;

    public EventoService(AdopetContext context)
    {
        _context = context;
    }

    public void GenerateFakeData()
    {
        var proprietario = new Cliente
        {
            Nome = "João Silva",
            CPF = "123.456.789-00",
            Email = "joao.silva@example.com"
        };
        _context.Add(proprietario);

        var pet = new Pet
        {
            Nome = "Rex",
            TipoPet = TipoPet.Cachorro
        };
        _context.Add(pet);
        _context.SaveChanges();
    }
}
