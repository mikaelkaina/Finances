using Financeiro.Application.DTOs;
using Financeiro.Application.UseCases;
using System;
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

        app.MapPost("/api/incomes", 
            async (
                AddIncomeInput input,
                AddIncomeUseCase useCase,
                ClaimsPrincipal user) =>
            {
                var userId = user.FindFirstValue(ClaimTypes.NameIdentifier);

                if (string.IsNullOrEmpty(userId))
                    return Results.Unauthorized();

                var command = input with { UserId = userId };

                await useCase.ExecuteAsync(command);

                return Results.Ok();

            })
            .RequireAuthorization();
    }
}
