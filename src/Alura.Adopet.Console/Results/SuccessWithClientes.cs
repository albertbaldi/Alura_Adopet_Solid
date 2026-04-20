using Alura.Adopet.Domain.Entities;
using FluentResults;

namespace Alura.Adopet.Console.Results;

public class SuccessWithClientes : Success
{
    public SuccessWithClientes(IEnumerable<Cliente> clientes, string mensagem) : base(mensagem)
    {
        Clientes = clientes;
    }

    public IEnumerable<Cliente> Clientes { get; set; }
}
