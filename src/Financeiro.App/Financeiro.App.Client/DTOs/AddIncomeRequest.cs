namespace Financeiro.App.Client.DTOs;

public record AddIncomeRequest(
    decimal Amount,
    string Description,
    DateTime Date);