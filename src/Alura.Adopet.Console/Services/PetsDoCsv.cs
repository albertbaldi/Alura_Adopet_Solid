using Alura.Adopet.Domain.Entities;

namespace Alura.Adopet.Console.Services;

public class PetsDoCsv : LeitorArquivoCsv<Pet>
{

    public PetsDoCsv(string caminhoDoArquivoASerLido) : base(caminhoDoArquivoASerLido)
    {
    }

    protected override Pet CreateObject(string linha)
    {
        string[]? propriedades = linha?.Split(';') ?? throw new ArgumentNullException("Texto não pode ser nulo!");

        if (string.IsNullOrEmpty(linha)) throw new ArgumentException("Texto não pode ser vazio");

        bool guidValido = Guid.TryParse(propriedades[0], out Guid petId);
        if (!guidValido) throw new ArgumentException("Identificador do pet inválido!");

        bool tipoValido = int.TryParse(propriedades[2], out int tipoPet);
        if (!tipoValido) throw new ArgumentException("Tipo do pet inválido!");

        //int[] enums = Array.ConvertAll(Enum.GetValues<TipoPet>(), value => (int)value);
        //if (!enums.Contains(tipoPet)) throw new ArgumentException("Tipo do pet inválido!");

        return new Pet(petId, propriedades[1], int.Parse(propriedades[2]) == 1 ? TipoPet.Gato : TipoPet.Cachorro);
    }
}