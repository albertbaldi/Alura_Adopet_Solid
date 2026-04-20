using Alura.Adopet.Console.Interfaces;

namespace Alura.Adopet.Console.Services;


public abstract class LeitorArquivoCsv<T> : ILeitorDeArquivo<T>
{
    private readonly string caminhoDoArquivoASerLido;

    protected LeitorArquivoCsv(string caminhoDoArquivoASerLido)
    {
        this.caminhoDoArquivoASerLido = caminhoDoArquivoASerLido;
    }

    protected abstract T CreateObject(string linha);

    public IEnumerable<T> RealizaLeitura()
    {
        if (string.IsNullOrEmpty(caminhoDoArquivoASerLido))
        {
            return null;
        }
        List<T> lista = new List<T>();
        using StreamReader sr = new StreamReader(caminhoDoArquivoASerLido);
        while (!sr.EndOfStream)
        {
            string? linha = sr.ReadLine();
            if (linha is not null)
            {
                T obj = CreateObject(linha);
                lista.Add(obj);
            }
        }
        return lista;
    }
}