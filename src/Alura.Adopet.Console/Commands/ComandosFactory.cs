using Alura.Adopet.Console.Interfaces;
using Alura.Adopet.Console.Services;

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

        switch (comando)
        {
            case "import":
                var httpClientPet = new HttpClientPet(new AdopetAPIClientFactory().CreateClient("adopet"));
                var leitorDeArquivos = new LeitorDeArquivo(args[1]);
                if (leitorDeArquivos is null) { return null; }
                return new Import(httpClientPet, leitorDeArquivos);

            case "list":
                var httpClientPetList = new HttpClientPet(new AdopetAPIClientFactory().CreateClient("adopet"));
                return new List(httpClientPetList);

            case "show":
                var leitorDeArquivosShow = new LeitorDeArquivo(args[1]);
                if (leitorDeArquivosShow is null) { return null; }
                return new Show(leitorDeArquivosShow);

            case "help":
                var comandoASerExibido = args.Length == 2 ? args[1] : null;
                return new Help(comandoASerExibido);

            default: return null;
        }

    }
}