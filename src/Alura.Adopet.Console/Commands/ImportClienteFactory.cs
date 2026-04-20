using Alura.Adopet.Console.Interfaces;
using Alura.Adopet.Console.Services;

namespace Alura.Adopet.Console.Commands;

public class ImportClienteFactory : IComandoFactory
{
    public bool ConsegueCriarOTipo(Type? tipoComando)
    {
        return tipoComando?.IsAssignableTo(typeof(ImportCliente)) ?? false;
    }

    public IComando? CriarComando(string[] argumentos)
    {
        var serviceClientes = new ClienteService(new AdopetAPIClientFactory().CreateClient("adopet"));
        var leitorArquivoClientes = LeitorDeArquivoFactory.CreateLeitorDeCliente(argumentos[1]);
        if (leitorArquivoClientes is null) return null;
        return new ImportCliente(serviceClientes, leitorArquivoClientes);
    }
}