using Alura.Adopet.Console.Attributes;
using Alura.Adopet.Console.Interfaces;
using Alura.Adopet.Console.Results;
using Alura.Adopet.Console.Util;
using FluentResults;
using System.Reflection;

namespace Alura.Adopet.Console.Commands;

[DocComando("help", "Adopet help [COMANDO] - exibe a ajuda dos comandos do sistema.")]
public class Help : IComando
{
    private Dictionary<string, DocComandoAttribute> docs;
    private string? comando;

    public Help(string? comando)
    {
        docs = DocumentacaoDoSistema.ToDictionary(Assembly.GetExecutingAssembly());
        this.comando = comando;
    }

    public Task<Result> ExecutarAsync()
    {
        try
        {
            return Task
                .FromResult(Result.Ok()
                .WithSuccess(new SuccessWithDocs(this.GerarDocumentacao())));
        }
        catch (Exception ex)
        {
            return Task.FromResult(Result.Fail(ex.Message));
        }
    }

    private IEnumerable<string> GerarDocumentacao()
    {
        List<string> documentacao = new();

        if (this.comando is null)
        {
            foreach (var doc in docs.Values)
            {
                documentacao.Add(doc.Descricao);
            }
        }
        else
        {
            if (docs.ContainsKey(this.comando))
            {
                var doc = docs[this.comando];
                documentacao.Add(doc.Descricao);
            }
            else
            {
                documentacao.Add($"Comando não encontrado!");
            }
        }

        return documentacao;
    }
}
