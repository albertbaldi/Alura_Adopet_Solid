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
                var httpClientPet = new PetService(new AdopetAPIClientFactory().CreateClient("adopet"));
                var leitorDeArquivos = LeitorDeArquivoFactory.CreateLeitorDePet(args[1]);
                if (leitorDeArquivos is null) { return null; }
                return new Import(httpClientPet, leitorDeArquivos);

            case "import-cliente":
                var httpClientCliente = new ClienteService(new AdopetAPIClientFactory().CreateClient("adopet"));
                var leitorDeArquivosCliente = LeitorDeArquivoFactory.CreateLeitorDeCliente(args[1]);
                if (leitorDeArquivosCliente is null) { return null; }
                return new ImportCliente(httpClientCliente, leitorDeArquivosCliente);
            case "list":
                var httpClientPetList = new PetService(new AdopetAPIClientFactory().CreateClient("adopet"));
                return new List(httpClientPetList);

            case "show":
                var leitorDeArquivosShow = LeitorDeArquivoFactory.CreateLeitorDePet(args[1]);
                if (leitorDeArquivosShow is null) { return null; }
                return new Show(leitorDeArquivosShow);

            case "help":
                var comandoASerExibido = args.Length == 2 ? args[1] : null;
                return new Help(comandoASerExibido);

            default: return null;
        }

    }
}