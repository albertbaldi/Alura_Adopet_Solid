using System;
using System.ComponentModel.DataAnnotations;

namespace Alura.Adopet.Domain.Entities;

public class Pet
{
    public Pet()
    {
        Id = Guid.NewGuid();
    }

    public Pet(Guid id, string? nome, TipoPet tipoPet)
    {
        Id = id;
        Nome = nome;
        TipoPet = tipoPet;
    }

    [Key]
    public Guid Id { get; set; }
    public string Nome { get; set; }
    public TipoPet TipoPet { get; set; }

    public override string ToString()
    {
        return $"{Id} - {Nome} - {TipoPet}";
    }
}
