using FluentAssertions;

namespace Finances.Tests.Domain;

public class FinancialEntryTestss
{
    [Fact]
    public void Income_Constructor_WithValidData_ShouldCreateIncome()
    {
        var income = new FinancialEntryBuilder().BuildIncome();

        income.Should().NotBeNull();
        income.Id.Should().NotBeEmpty();
        income.Amount.Should().BeGreaterThan(0);
    }

    [Fact]
    public void Expense_Constructor_WithValidData_ShouldCreateExpense()
    {
        var expense = new FinancialEntryBuilder().BuildExpense();

        expense.Should().NotBeNull();
        expense.Id.Should().NotBeEmpty();
        expense.Amount.Should().BeGreaterThan(0);
    }

    [Fact]
    public void Income_UpdateIncome_WithValidData_ShouldUpdateProperties()
    {
        var income = new FinancialEntryBuilder().BuildIncome();
        var newAmount = 500.50m;
        var newDescription = "Salário atualizado";
        var newDate = DateTime.UtcNow.AddDays(-1);

        income.UpdateIncome(newAmount, newDescription, newDate);

        income.Amount.Should().Be(newAmount);
        income.Description.Should().Be(newDescription);
        income.Date.Should().Be(newDate);
    }

    [Fact]
    public void Expense_UpdateExpense_WithValidData_ShouldUpdateProperties()
    {
        var expense = new FinancialEntryBuilder().BuildExpense();
        var newAmount = 150.00m;
        var newDescription = "Conta de luz";
        var newDate = DateTime.UtcNow.AddDays(-2);

        expense.UpdateExpense(newAmount, newDescription, newDate);

        expense.Amount.Should().Be(newAmount);
        expense.Description.Should().Be(newDescription);
        expense.Date.Should().Be(newDate);
    }

    [Theory]
    [InlineData("")]
    [InlineData(" ")]
    [InlineData(null)]
    public void Constructor_WithInvalidUserId_ShouldThrowException(string? invalidUserId)
    {
        Action action = () => new FinancialEntryBuilder()
            .WithUserId(invalidUserId)
            .BuildIncome();
        
        action.Should().Throw<ArgumentException>()
            .WithMessage("UserID is required.*");
    }

    [Theory]
    [InlineData(0)]
    [InlineData(-1)]
    [InlineData(-100.50)]
    public void Constructor_WithInvalidAmount_ShouldThrowException(decimal invalidAmount)
    {
        Action action = () => new FinancialEntryBuilder()
            .WithAmount(invalidAmount)
            .BuildIncome();

        action.Should().Throw<ArgumentException>()
            .WithMessage("Amount must be greater than zero.*");
    }

    [Fact]
    public void Constructor_WithFutureDate_ShouldThrowException()
    {
        var futureDate = DateTime.UtcNow.AddDays(1);
      
        Action action = () => new FinancialEntryBuilder()
            .WithDate(futureDate)
            .BuildIncome();

        action.Should().Throw<ArgumentException>()
            .WithMessage("Date cannot be in the future.*");
    }

    [Fact]
    public void Update_WithInvalidAmount_ShouldThrowException()
    {
        var income = new FinancialEntryBuilder().BuildIncome();
        var invalidAmount = -50m;

        Action action = () => income.UpdateIncome(invalidAmount, "Teste", DateTime.UtcNow);

        action.Should().Throw<Exception>()
            .WithMessage("Amount must be greater than zero.*");
    }
}