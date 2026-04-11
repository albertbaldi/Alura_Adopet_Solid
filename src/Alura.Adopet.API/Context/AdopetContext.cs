using System;
using Alura.Adopet.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Alura.Adopet.API.Context;

public class AdopetContext : DbContext
{
    public AdopetContext(DbContextOptions<AdopetContext> options) : base(options)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.LogTo(Console.WriteLine);
    }

    public DbSet<Cliente> Cliente { get; set; }
    public DbSet<Pet> Pet { get; set; }
}
