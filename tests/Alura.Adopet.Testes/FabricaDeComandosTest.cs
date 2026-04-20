using Alura.Adopet.Console.Commands;

namespace Alura.Adopet.Testes;

public class FabricaDeComandosTest
{
    [Theory]
    [InlineData("import", "Import")]
    [InlineData("import-cliente", "ImportCliente")]
    [InlineData("show", "Show")]
    [InlineData("list", "List")]
    [InlineData("help", "Help")]
    public void DadoParametroValidoDeveRetornarObjetoNaoNulo(string instrucao, string nomeTipo)
    {
        // arrange
        string[] args = new[] { instrucao, "lista.csv" };
        // act
        var comando = ComandosFactory.CriarComando(args);
        // assert
        Assert.NotNull(comando);
        Assert.Equal(nomeTipo, comando.GetType().Name);
    }
}
