using Alura.Adopet.Console.Interfaces;
using Alura.Adopet.Domain.Entities;

namespace Alura.Adopet.Console.Services;


public static class LeitorDeArquivoFactory
{
    public static ILeitorDeArquivo<Cliente>? CreateLeitorDeCliente(string caminhoArquivo)
    {
        return Path.GetExtension(caminhoArquivo) switch
        {
            ".csv" => new ClientesDoCsv(caminhoArquivo),
            ".json" => new ClientesDoJson(caminhoArquivo),
            _ => null
        };
    }

    public static ILeitorDeArquivo<Pet>? CreateLeitorDePet(string caminhoArquivo)
    {
        return Path.GetExtension(caminhoArquivo) switch
        {
            ".csv" => new PetsDoCsv(caminhoArquivo),
            ".json" => new PetsDoJson(caminhoArquivo),
            _ => null
        };
    }
}