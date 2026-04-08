using System;
using System.ComponentModel.DataAnnotations;

namespace Alura.Adopet.API.Domain;

public class Cliente
{
    public Cliente()
    {
        Id = Guid.NewGuid();
    }

    [Key]
    public Guid Id { get; set; }
    public string Nome { get; set; }
    public string CPF { get; set; }
    public string Email { get; set; }
}
