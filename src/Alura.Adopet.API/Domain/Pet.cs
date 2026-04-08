using System;
using System.ComponentModel.DataAnnotations;

namespace Alura.Adopet.API.Domain;

public class Pet
{
    public Pet()
    {
        Id = Guid.NewGuid();
    }

    [Key]
    public Guid Id { get; set; }
    public string Nome { get; set; }
    public TipoPet TipoPet { get; set; }
}
