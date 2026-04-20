using Alura.Adopet.Console.Interfaces;
using Alura.Adopet.Domain.Entities;
using System.Net.Http.Json;

namespace Alura.Adopet.Console.Services;

public class ClienteService : IApiService<Cliente>
{
    private readonly HttpClient client;
    public ClienteService(HttpClient client)
    {
        this.client = client;
    }

    public async Task CreateAsync(Cliente cliente)
    {
        await client.PostAsJsonAsync("cliente/add", cliente);
    }

    public async Task<IEnumerable<Cliente>?> ListAsync()
    {
        HttpResponseMessage response = await client.GetAsync("cliente/list");
        return await response.Content.ReadFromJsonAsync<IEnumerable<Cliente>>();

    }

}
