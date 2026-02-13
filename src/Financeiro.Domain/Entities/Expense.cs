namespace Financeiro.Domain.Entities;

public sealed class Expense : FinancialEntry
{
    public Expense(string userId, decimal amount, string description, DateTime date) 
        : base(userId, amount, description, date)
    {
    }

    public void UpdateExpense(decimal amount, string description, DateTime date)
    {
        Update(amount, description, date);
    }
}
