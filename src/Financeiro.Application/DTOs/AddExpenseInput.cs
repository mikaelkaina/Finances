namespace Financeiro.Application.DTOs;

public record AddExpenseInput(
    string UserId,
    Decimal Amount,
    string Description,
    DateTime Date);
