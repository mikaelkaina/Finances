namespace Financeiro.App.Client.DTOs.ExpenseDtos;

public record AddExpenseRequest(
     decimal Amount,
     string Description,
     DateTime Date
);

   

