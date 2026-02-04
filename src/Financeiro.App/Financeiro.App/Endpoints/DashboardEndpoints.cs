using Financeiro.Application.UseCases;
using System.Security.Claims;

namespace Financeiro.App.Endpoints;

public static class DashboardEndpoints
{
    public static void MapDashboardEndpoints(this WebApplication app)
    {
        app.MapGet("/api/dashboard/summary", 
            async (
            ClaimsPrincipal user,
            GetMonthlySummaryUseCase useCase) =>
        {
            var userId = user.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            if (string.IsNullOrEmpty(userId))
                return Results.Unauthorized();

            var result = await useCase.ExecuteAsync(
                userId,
                DateTime.Now.Month,
                DateTime.Now.Year
            );

            return Results.Ok(result);
        })
            .RequireAuthorization();
    }
}
