namespace Financeiro.App.Client.DTOs.ExpenseDtos;

public record UpdateExpenseRequest(
    decimal Amount,
    string Description,
    DateTime Date
);
