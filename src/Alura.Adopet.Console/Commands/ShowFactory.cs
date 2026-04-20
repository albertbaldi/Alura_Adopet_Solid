using Alura.Adopet.Console.Interfaces;
using Alura.Adopet.Console.Services;

namespace Alura.Adopet.Console.Commands;

public class ShowFactory : IComandoFactory
{
    public bool ConsegueCriarOTipo(Type? tipoComando)
    {
        return tipoComando?.IsAssignableTo(typeof(Show)) ?? false;
    }

    public IComando? CriarComando(string[] args)
    {
        var leitorDeArquivosShow = LeitorDeArquivoFactory.CreateLeitorDePet(args[1]);
        if (leitorDeArquivosShow is null) return null;

        return new Show(leitorDeArquivosShow);
    }
}
