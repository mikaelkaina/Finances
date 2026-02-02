using Financeiro.Application.UseCases;
using Microsoft.Extensions.DependencyInjection;

namespace Financeiro.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<GetMonthlySummaryUseCase>();
        services.AddScoped<AddIncomeUseCase>();
        services.AddScoped<AddExpenseUseCase>();

        return services;
    }
}