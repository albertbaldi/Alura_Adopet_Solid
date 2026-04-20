using Alura.Adopet.Console.Interfaces;
using Alura.Adopet.Domain.Entities;
using System.Net.Http.Json;

namespace Alura.Adopet.Console.Services;

public class PetService : IApiService<Pet>
{
    private readonly HttpClient client;

    public PetService(HttpClient client)
    {
        this.client = client;
    }

    public Task CreateAsync(Pet pet)
    {
        return client.PostAsJsonAsync("pet/add", pet);
    }

    public async Task<IEnumerable<Pet>?> ListAsync()
    {
        HttpResponseMessage response = await client.GetAsync("pet/list");
        return await response.Content.ReadFromJsonAsync<IEnumerable<Pet>>();
    }
}
