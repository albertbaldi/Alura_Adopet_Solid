using Alura.Adopet.Console.Attributes;
using Alura.Adopet.Console.Interfaces;
using Alura.Adopet.Console.Results;
using Alura.Adopet.Domain.Entities;
using FluentResults;

namespace Alura.Adopet.Console.Commands;

[DocComando("list", "adopet list comando que exibe no terminal o conteúdo cadastrado na base de dados da AdoPet.")]
public class List : IComando
{
    private readonly IApiService<Pet> _apiService;

    public List(IApiService<Pet> apiService)
    {
        this._apiService = apiService;
    }

    public Task<Result> ExecutarAsync()
    {
        return this.ListaDadosPetsDaAPIAsync();
    }

    private async Task<Result> ListaDadosPetsDaAPIAsync()
    {
        try
        {
            var pets = await _apiService.ListAsync();
            return Result.Ok().WithSuccess(new SuccessWithPets(pets, "Listagem de Pet's realizada com sucesso!"));
        }
        catch (Exception exception)
        {
            return Result.Fail(new Error("Listagem falhou!").CausedBy(exception));
        }
    }
}
