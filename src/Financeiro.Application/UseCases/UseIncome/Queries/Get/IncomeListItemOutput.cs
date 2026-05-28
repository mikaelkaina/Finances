namespace Financeiro.Application.UseCases.UseIncome.Queries.Get;

public record IncomeListItemOutput(
    Guid Id,
    decimal Amount,
    string Description,
    DateTime Date
);
