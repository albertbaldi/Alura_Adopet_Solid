using Alura.Adopet.Console.Interfaces;
using Alura.Adopet.Console.Services;

namespace Alura.Adopet.Console.Commands;

public class ImportFactory : IComandoFactory
{
    public bool ConsegueCriarOTipo(Type? tipoComando)
    {
        return tipoComando?.IsAssignableTo(typeof(Import)) ?? false;
    }

    public IComando? CriarComando(string[] argumentos)
    {
        var servicePets = new PetService(new AdopetAPIClientFactory().CreateClient("adopet"));
        var leitorArquivoPets = LeitorDeArquivoFactory.CreateLeitorDePet(argumentos[1]);
        if (leitorArquivoPets is null) return null;
        return new Import(servicePets, leitorArquivoPets);
    }
}
