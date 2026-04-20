namespace Alura.Adopet.Console.Interfaces;

public interface IComandoFactory
{
    bool ConsegueCriarOTipo(Type? tipoComando);
    IComando? CriarComando(string[] args);
}
