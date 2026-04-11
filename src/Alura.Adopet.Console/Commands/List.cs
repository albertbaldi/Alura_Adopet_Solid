using System;
using Alura.Adopet.Console.Attributes;
using Alura.Adopet.Console.Interfaces;
using Alura.Adopet.Console.Results;
using Alura.Adopet.Console.Services;
using Alura.Adopet.Domain.Entities;
using FluentResults;

namespace Alura.Adopet.Console.Commands;

[DocComando("list", "adopet list comando que exibe no terminal o conteúdo cadastrado na base de dados da AdoPet.")]
public class List : IComando
{
    private readonly HttpClientPet clientPet;

    public List(HttpClientPet clientPet)
    {
        this.clientPet = clientPet;
    }

    public Task<Result> ExecutarAsync()
    {
        return this.ListaDadosPetsDaAPIAsync();
    }

    private async Task<Result> ListaDadosPetsDaAPIAsync()
    {
        try
        {
            var pets = await clientPet.ListAsync();
            return Result.Ok().WithSuccess(new SuccessWithPets(pets, "Listagem de Pet's realizada com sucesso!"));
        }
        catch (Exception exception)
        {
            return Result.Fail(new Error("Listagem falhou!").CausedBy(exception));
        }
    }
}
