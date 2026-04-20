namespace Alura.Adopet.Console.Interfaces;

public interface IApiService<T>
{
    Task CreateAsync(T obj);
    Task<IEnumerable<T>?> ListAsync();
}