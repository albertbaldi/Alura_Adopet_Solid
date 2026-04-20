namespace Alura.Adopet.Console.Interfaces;

public interface ILeitorDeArquivo<T>
{
    IEnumerable<T> RealizaLeitura();
}