namespace Financeiro.App.Client.DTOs.ExpenseDtos;

public record ExpenseResponse(
    Guid Id,
    DateTime Date,
    string Description,
    decimal Amount
);
