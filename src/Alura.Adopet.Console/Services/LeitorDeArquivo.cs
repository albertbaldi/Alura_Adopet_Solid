using System;
using Alura.Adopet.Domain.Entities;

namespace Alura.Adopet.Console.Services;

public class LeitorDeArquivo
{
    private string caminhoDoArquivoASerLido;
    public LeitorDeArquivo(string caminhoDoArquivoASerLido)
    {
        this.caminhoDoArquivoASerLido = caminhoDoArquivoASerLido;
    }

    public virtual List<Pet> RealizaLeitura()
    {
        if (string.IsNullOrEmpty(caminhoDoArquivoASerLido))
        {
            return null;
        }

        List<Pet> lista = new List<Pet>();
        using StreamReader sr = new StreamReader(caminhoDoArquivoASerLido);
        while (!sr.EndOfStream)
        {
            string? linha = sr.ReadLine();
            if (linha is not null)
            {
                string[] propriedades = linha.Split(';');
                bool guidValido = Guid.TryParse(propriedades[0], out Guid petId);
                if (!guidValido) throw new ArgumentException("Identificador do pet inválido!");

                bool tipoValido = int.TryParse(propriedades[2], out int tipoPet);
                if (!tipoValido) throw new ArgumentException("Tipo do pet inválido!");

                TipoPet tipo = tipoPet == 1 ? TipoPet.Gato : TipoPet.Cachorro;

                lista.Add(new Pet(petId, propriedades[1], tipo));
            }
        }
        return lista;
    }
}