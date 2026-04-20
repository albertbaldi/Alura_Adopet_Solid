using Alura.Adopet.Domain.Entities;

namespace Alura.Adopet.Console.Services;

public class ClientesDoJson : LeitorDeArquivoJson<Cliente>
{
    public ClientesDoJson(string caminhoArquivo) : base(caminhoArquivo)
    {
    }
}