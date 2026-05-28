namespace Financeiro.Application.UseCases.UseExpense.Queries.Get;

public record IncomeListItemOutput(
    Guid Id,
    decimal Amount,
    string Description,
    DateTime Date
);
