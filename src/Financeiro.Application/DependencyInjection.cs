using Financeiro.Application.UseCases;
using Financeiro.Application.UseCases.UseExpense;
using Financeiro.Application.UseCases.UseIncome;
using Microsoft.Extensions.DependencyInjection;

namespace Financeiro.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<GetMonthlySummaryUseCase>();

        services.AddScoped<AddIncomeUseCase>();
        services.AddScoped<AddExpenseUseCase>();
        
        services.AddScoped<GetIncomesUseCase>();
        services.AddScoped<GetExpensesUseCase>();

        services.AddScoped<DeleteIncomeUseCase>();
        services.AddScoped<DeleteExpenseUseCase>();

        services.AddScoped<UpdateIncomeUseCase>();
        services.AddScoped<UpdateExpenseUseCase>();

        return services;
    }
}