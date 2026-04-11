using FluentResults;

namespace Alura.Adopet.Console.Results;

public class SuccessWithDocs : Success
{
    public SuccessWithDocs(IEnumerable<string> documentacao)
    {
        Documentacao = documentacao;
    }

    public IEnumerable<string> Documentacao { get; }
}