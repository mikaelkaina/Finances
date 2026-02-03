using Financeiro.App.Client.DTOs;
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
}
