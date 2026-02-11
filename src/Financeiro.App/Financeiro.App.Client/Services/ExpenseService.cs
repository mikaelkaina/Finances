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
        var response = await _http.PostAsJsonAsync("api/expenses", request);
        response.EnsureSuccessStatusCode();
    }

    public async Task<IEnumerable<ExpenseResponse>> GetAllAsync()
    {
        return await _http.GetFromJsonAsync<IEnumerable<ExpenseResponse>>("/api/expenses")
               ?? Enumerable.Empty<ExpenseResponse>();
    }

    public async Task DeleteAsync(Guid expenseId)
    {
        var response = await _http.DeleteAsync($"api/expenses/{expenseId}");
        response.EnsureSuccessStatusCode();
    }
}
