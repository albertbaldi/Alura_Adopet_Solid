using Alura.Adopet.Console.Attributes;
using Alura.Adopet.Console.Interfaces;
using Alura.Adopet.Console.Results;
using Alura.Adopet.Domain.Entities;
using FluentResults;

namespace Alura.Adopet.Console.Commands;

[DocComando("import-cliente", "Adopet import-cliente <ARQUIVO> comando que realiza a importação do arquivo de clientes.")]
public class ImportCliente : IComando
{
    private readonly IApiService<Cliente> _apiService;
    private readonly ILeitorDeArquivo<Cliente> _leitorDeArquivo;

    public ImportCliente(IApiService<Cliente> apiService, ILeitorDeArquivo<Cliente> leitorDeArquivo)
    {
        _apiService = apiService;
        _leitorDeArquivo = leitorDeArquivo;
    }

    public async Task<Result> ExecutarAsync()
    {
        try
        {
            var lista = _leitorDeArquivo.RealizaLeitura();
            foreach (var cliente in lista)
            {
                await _apiService.CreateAsync(cliente);
            }

            return Result.Ok().WithSuccess(new SuccessWithClientes(lista, "Importação realizada com sucesso!"));
        }
        catch (Exception ex)
        {
            return Result.Fail(new Error("Importação falhou!").CausedBy(ex));
        }
    }
}
