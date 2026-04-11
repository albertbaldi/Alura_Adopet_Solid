using Alura.Adopet.Console.Commands;
using Alura.Adopet.Console.Interfaces;

IComando? comando = ComandosFactory.CriarComando(args);

if (comando is not null)
{
    var resultado = await comando.ExecutarAsync();
    Console.WriteLine(resultado);
}
else
{
    Console.WriteLine("Comando não reconhecido.");
}