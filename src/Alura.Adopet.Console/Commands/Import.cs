using Alura.Adopet.Console.Attributes;
using Alura.Adopet.Console.Interfaces;
using Alura.Adopet.Console.Results;
using Alura.Adopet.Domain.Entities;
using FluentResults;

namespace Alura.Adopet.Console.Commands;

[DocComando("import", "Adopet import <ARQUIVO> comando que realiza a importação do arquivo de pets.")]
public class Import : IComando
{
    private readonly IApiService<Pet> _apiService;
    private readonly ILeitorDeArquivo<Pet> _leitorDeArquivo;

    public Import(IApiService<Pet> apiService, ILeitorDeArquivo<Pet> leitorDeArquivo)
    {
        this._apiService = apiService;
        this._leitorDeArquivo = leitorDeArquivo;
    }

    public async Task<Result> ExecutarAsync()
    {
        return await this.ImportacaoArquivoPetAsync();
    }

    private async Task<Result> ImportacaoArquivoPetAsync()
    {
        try
        {
            var listaDePet = _leitorDeArquivo.RealizaLeitura();
            foreach (var pet in listaDePet)
            {
                await _apiService.CreateAsync(pet);
            }
            return Result.Ok().WithSuccess(new SuccessWithPets(listaDePet, "Importação Realizada com Sucesso!"));
        }
        catch (Exception exception)
        {

            return Result.Fail(new Error("Importação falhou!").CausedBy(exception));
        }




    }
}
