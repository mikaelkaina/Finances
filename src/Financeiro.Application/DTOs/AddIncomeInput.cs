namespace Financeiro.Application.DTOs;

public record AddIncomeInput(
    string UserId,
    decimal Amount,
    string Description,
    DateTime Date);
