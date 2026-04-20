using Alura.Adopet.Console.Attributes;
using Alura.Adopet.Console.Interfaces;
using System.Reflection;

namespace Alura.Adopet.Console.Extensions;

public static class ComandoExtensions
{
    public static Type? GetTipoDoComando(this Assembly assembly, string comando)
    {
        return assembly
            .GetTypes()
            // filtre todos os tipos concretos que implementam IComando
            // IComando cmd = new Import(...)
            .Where(t => !t.IsInterface && t.IsAssignableTo(typeof(IComando)))
            // filtre os comandos que atendem a instrução armazenada em "comando"
            .Where(c => c.GetCustomAttributes<DocComandoAttribute>()
                .Any(a => a.Instrucao.Equals(comando)))
            .FirstOrDefault();
    }
}
