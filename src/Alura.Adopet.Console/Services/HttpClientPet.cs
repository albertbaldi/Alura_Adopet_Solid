using System.Net.Http.Json;
using Alura.Adopet.Domain.Entities;

namespace Alura.Adopet.Console.Services;

public class HttpClientPet
{
    private HttpClient client;

    public HttpClientPet(HttpClient client)
    {
        this.client = client;
    }

    public virtual Task CreateAsync(Pet pet)
    {
        return client.PostAsJsonAsync("pet/add", pet);
    }

    public virtual async Task<IEnumerable<Pet>?> ListAsync()
    {
        HttpResponseMessage response = await client.GetAsync("pet/list");
        return await response.Content.ReadFromJsonAsync<IEnumerable<Pet>>();
    }
}