using Financeiro.App.Client.DTOs.ExpenseDtos;
using System.Net.Http.Json;

namespace Financeiro.App.Client.Services;

public class ExpenseService
{
    private readonly HttpClient _http;

    public ExpenseService(HttpClient http)
    {
        _http = http;
    }

    public async Task AddAsync(AddExpenseRequest request)
    {
        var response = await _http.PostAsJsonAsync("/expenses", request);
        response.EnsureSuccessStatusCode();
    }
}
