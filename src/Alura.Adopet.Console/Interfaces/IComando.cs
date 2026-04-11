using System.IO.Pipelines;
using FluentResults;

namespace Alura.Adopet.Console.Interfaces;

public interface IComando
{
    Task<Result> ExecutarAsync();
}