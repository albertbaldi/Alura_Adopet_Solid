using Alura.Adopet.Domain.Entities;
using FluentResults;

namespace Alura.Adopet.Console.Results;

public class SuccessWithPets : Success
{
    public SuccessWithPets(IEnumerable<Pet> pets, string mensagem) : base(mensagem)
    {
        Pets = pets;
    }

    public IEnumerable<Pet> Pets { get; }
}