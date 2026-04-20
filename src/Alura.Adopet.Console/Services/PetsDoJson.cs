using Alura.Adopet.Domain.Entities;

namespace Alura.Adopet.Console.Services;

public class PetsDoJson : LeitorDeArquivoJson<Pet>
{
    public PetsDoJson(string caminhoArquivo) : base(caminhoArquivo)
    {
    }
}