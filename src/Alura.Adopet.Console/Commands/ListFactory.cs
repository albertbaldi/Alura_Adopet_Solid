using Alura.Adopet.Console.Interfaces;
using Alura.Adopet.Console.Services;

namespace Alura.Adopet.Console.Commands;

public class ListFactory : IComandoFactory
{
    public bool ConsegueCriarOTipo(Type? tipoComando)
    {
        return tipoComando?.IsAssignableTo(typeof(Alura.Adopet.Console.Commands.List)) ?? false;
    }
    public IComando? CriarComando(string[] args)
    {
        var httpClientPetList = new PetService(new AdopetAPIClientFactory().CreateClient("adopet"));
        return new Alura.Adopet.Console.Commands.List(httpClientPetList);
    }
}
