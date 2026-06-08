using Bogus;
using Financeiro.Domain.Entities;

namespace Finances.Tests.Domain;

public class FinancialEntryBuilder
{
    private string _userId;
    private string _description;
    private decimal _amount;
    private DateTime _date;

    public FinancialEntryBuilder()
    {
        var faker = new Faker();
        _userId = Guid.NewGuid().ToString();
        _amount = faker.Random.Decimal(1, 10000);
        _description = faker.Lorem.Sentence();
        _date = faker.Date.Past();
    }

    public FinancialEntryBuilder WithUserId(string userId)
    {
        _userId = userId;
        return this;
    }

    public FinancialEntryBuilder WithDate(DateTime date)
    {
        _date = date;
        return this;
    }

    public FinancialEntryBuilder WithAmount(decimal amount)
    {
        _amount = amount;
        return this;
    }
    
    public Income BuildIncome() => new Income(_userId, _amount, _description, _date);
    public Expense BuildExpense() => new Expense(_userId, _amount, _description, _date);
}