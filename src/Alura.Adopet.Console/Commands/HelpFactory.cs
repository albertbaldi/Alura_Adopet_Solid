using Alura.Adopet.Console.Interfaces;

namespace Alura.Adopet.Console.Commands;

public class HelpFactory : IComandoFactory
{
    public bool ConsegueCriarOTipo(Type? tipoComando)
    {
        return tipoComando?.IsAssignableTo(typeof(Help)) ?? false;
    }
    public IComando? CriarComando(string[] args)
    {
        var comandoASerExibido = args.Length == 2 ? args[1] : null;
        return new Help(comandoASerExibido);
    }
}
