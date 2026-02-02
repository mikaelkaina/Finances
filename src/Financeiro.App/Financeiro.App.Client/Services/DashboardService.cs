using Financeiro.Application.DTOs;
using System.Net.Http.Json;

namespace Financeiro.App.Client.Services;

public class DashboardService
{
    private readonly HttpClient _http;

    public DashboardService(HttpClient http)
    {
        _http = http;
    }

    public async Task<MonthlySummaryOutput?> GetSummaryAsync()
    {
        return await _http.GetFromJsonAsync<MonthlySummaryOutput>(
            "/api/dashboard/summary");
    }
}
