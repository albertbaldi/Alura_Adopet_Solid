using Alura.Adopet.Console.Interfaces;
using System.Text.Json;

namespace Alura.Adopet.Console.Services;

public class LeitorDeArquivoJson<T> : ILeitorDeArquivo<T>
{
    private string caminhoArquivo;
    public LeitorDeArquivoJson(string caminhoArquivo)
    {
        this.caminhoArquivo = caminhoArquivo;
    }

    public IEnumerable<T> RealizaLeitura()
    {
        using var stream = new FileStream(caminhoArquivo, FileMode.Open, FileAccess.Read);
        return JsonSerializer.Deserialize<IEnumerable<T>>(stream) ?? Enumerable.Empty<T>();
    }
}