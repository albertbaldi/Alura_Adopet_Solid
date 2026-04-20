using Alura.Adopet.Console.Extensions;
using Alura.Adopet.Console.Interfaces;
using Alura.Adopet.Console.Services;
using System.Reflection;

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

        Type? tipoQueAtendeAInstrucao = Assembly.GetExecutingAssembly().GetTipoDoComando(comando);

        if (tipoQueAtendeAInstrucao is null)
        {
            return null;
        }

        IEnumerable<IComandoFactory> fabricasDeComando = Assembly.GetExecutingAssembly().GetTypes()
            .Where(t => !t.IsInterface && t.IsAssignableFrom(t))
            .Select(f => (IComandoFactory)Activator.CreateInstance(f)!);

        IComandoFactory? fabrica = fabricasDeComando.FirstOrDefault(f => f.ConsegueCriarOTipo(tipoQueAtendeAInstrucao));

        if (fabrica is null)
        {
            return null;
        }

        return fabrica.CriarComando(args);
    }
}