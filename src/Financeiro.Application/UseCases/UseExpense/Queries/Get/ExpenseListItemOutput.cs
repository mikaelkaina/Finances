namespace Financeiro.Application.UseCases.UseExpense.Queries.Get;

public record ExpenseListItemOutput(
    Guid Id,
    decimal Amount,
    string Description,
    DateTime Date
);
