using System;
using Alura.Adopet.Console.Attributes;
using Alura.Adopet.Console.Interfaces;
using Alura.Adopet.Console.Services;
using FluentResults;

namespace Alura.Adopet.Console.Commands;

[DocComando("import", "Adopet import <ARQUIVO> comando que realiza a importação do arquivo de pets.")]
public class Import : IComando
{
    private readonly HttpClientPet clientPet;
    private readonly LeitorDeArquivo leitorDeArquivo;

    public Import(HttpClientPet clientPet, LeitorDeArquivo leitorDeArquivo)
    {
        this.clientPet = clientPet;
        this.leitorDeArquivo = leitorDeArquivo;
    }

    public Task<Result> ExecutarAsync()
    {
        throw new NotImplementedException();
    }
}
