using Alura.Adopet.Console.Attributes;
using Alura.Adopet.Console.Interfaces;
using Alura.Adopet.Console.Results;
using Alura.Adopet.Domain.Entities;
using FluentResults;

namespace Alura.Adopet.Console.Commands;

[DocComando("show", "adopet show <ARQUIVO> comando que exibe no terminal o conteúdo do arquivo importado.")]
public class Show : IComando
{
    private readonly ILeitorDeArquivo<Pet> _leitorDeArquivo;

    public Show(ILeitorDeArquivo<Pet> leitorDeArquivo)
    {
        this._leitorDeArquivo = leitorDeArquivo;
    }

    public Task<Result> ExecutarAsync()
    {
        try
        {
            return this.ExibeConteudoArquivo();
        }
        catch (Exception exception)
        {
            return Task.FromResult(Result.Fail(new Error("Exibição do arquivo falhou!").CausedBy(exception)));
        }
    }

    private Task<Result> ExibeConteudoArquivo()
    {
        var listaDepets = _leitorDeArquivo.RealizaLeitura();
        return Task.FromResult(Result.Ok().WithSuccess(new SuccessWithPets(listaDepets, "Exibição do arquivo realizada com sucesso!")));

    }
}
