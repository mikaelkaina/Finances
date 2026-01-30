namespace Financeiro.Domain.Entities;

public sealed class Expense : FinancialEntry
{
    public Expense(Guid id, string userId, decimal amount, string description, DateTime date) 
        : base(id, userId, amount, description, date)
    {
    }
}
