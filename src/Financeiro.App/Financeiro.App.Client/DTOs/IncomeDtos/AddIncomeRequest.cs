namespace Financeiro.App.Client.DTOs.IncomeDtos;

public record AddIncomeRequest(
    decimal Amount,
    string Description,
    DateTime Date);