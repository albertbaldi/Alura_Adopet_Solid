namespace Alura.Adopet.Console.Attributes;

[AttributeUsage(AttributeTargets.Class)]
public sealed class DocComandoAttribute : Attribute
{
    public DocComandoAttribute(string instrucao, string descricao)
    {
        Instrucao = instrucao;
        Descricao = descricao;
    }

    public string Instrucao { get; }
    public string Descricao { get; }

}