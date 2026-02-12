using Financeiro.App.Client.DTOs.IncomeDtos;
using System.Net.Http.Json;

namespace Financeiro.App.Client.Services;

public class IncomeService
{
    private readonly HttpClient _http;

    public IncomeService(HttpClient http)
    {
        _http = http;
    }

    public async Task AddAsync(AddIncomeRequest request)
    {
        var response = await _http.PostAsJsonAsync("api/incomes", request);
        response.EnsureSuccessStatusCode();
    }

    public async Task<IEnumerable<IncomeResponse>> GetAllAsync()
    {
        return await _http.GetFromJsonAsync<IEnumerable<IncomeResponse>>("api/incomes")
               ?? Enumerable.Empty<IncomeResponse>();
    }

    public async Task DeleteAsync(Guid incomeId)
    {
        var response = await _http.DeleteAsync($"api/incomes/{incomeId}");
        response.EnsureSuccessStatusCode();
    }

    public async Task UpdateAsync(Guid incomeId, UpdateIncomeRequest request)
    {
        var response = await _http.PutAsJsonAsync(
            $"api/incomes/{incomeId}",
            request
        );

        response.EnsureSuccessStatusCode();
    }
}
