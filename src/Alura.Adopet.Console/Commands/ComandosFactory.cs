using Alura.Adopet.Console.Extensions;
using Alura.Adopet.Console.Interfaces;

namespace Alura.Adopet.Console.Commands;

public static class ComandosFactory
{
    public static IComando? CriarComando(string[] args)
    {
        if (args is null || args.Length == 0)
        {
            return null;
        }

        string comando = args[0];

        // Use the assembly that contains this factory to locate commands and factories.
        var assembly = typeof(ComandosFactory).Assembly;

        Type? tipoQueAtendeAInstrucao = assembly.GetTipoDoComando(comando);

        if (tipoQueAtendeAInstrucao is null)
        {
            return null;
        }

        IEnumerable<IComandoFactory> fabricasDeComando = assembly.GetTypes()
            .Where(t => !t.IsInterface && typeof(IComandoFactory).IsAssignableFrom(t))
            .Select(f => (IComandoFactory)Activator.CreateInstance(f)!);

        IComandoFactory? fabrica = fabricasDeComando.FirstOrDefault(f => f.ConsegueCriarOTipo(tipoQueAtendeAInstrucao));

        if (fabrica is null)
        {
            return null;
        }

        return fabrica.CriarComando(args);
    }
}