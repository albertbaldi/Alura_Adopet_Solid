using Alura.Adopet.Console.Interfaces;
using Moq;

namespace Alura.Adopet.Testes.Builder;

public static class ApiServiceMockBuilder
{
    public static Mock<IApiService<T>> GetMock<T>() where T : class
        => new(MockBehavior.Default);

    public static Mock<IApiService<T>> GetMockList<T>(List<T> lista) where T : class
    {
        var mockService = new Mock<IApiService<T>>(MockBehavior.Default);
        mockService.Setup(service => service.ListAsync())
            .ReturnsAsync(lista);
        return mockService;
    }
}