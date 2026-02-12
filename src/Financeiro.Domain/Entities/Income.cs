namespace Financeiro.Domain.Entities;

public sealed class Income : FinancialEntry
{
    public Income(string userId, decimal amount, string description, DateTime date)
         : base(userId, amount, description, date)
    {
    }

    public void UpdateIncome(decimal amount,string description, DateTime date)
    {
        Update(amount, description, date);
    }
}
