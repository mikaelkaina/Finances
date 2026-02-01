using Financeiro.Domain.Entities;
using Financeiro.Domain.Exceptions;
using FluentAssertions;

namespace Domain.Tests;

public class FinancialEntryTests
{
    [Fact]
    [Trait("Category", "Domain")]
    public void Constructor_WitjValidData_ShoulCreateIncome()
    {
        //Arrange
        var userId = Guid.NewGuid().ToString();
        var amount = 150.50m;
        var description = "Salário";
        var date = DateTime.UtcNow;

        //Act
        var income = new Income(userId, amount, description, date);

        //Assert
        income.UserId.Should().Be(userId);
        income.Amount.Should().Be(amount);
        income.Description.Should().Be(description);
        income.Date.Should().Be(date);
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData("   ")]
    public void Constructor_InvalidUserId_ShouldThrowDomainException(string invalidUserId)
    {
        //Arrange
        var action = () => new Income(invalidUserId!, 100m, "Description", DateTime.UtcNow);

        //Act & Assert
        action.Should().Throw<DomainException>()
            .WithMessage("UserId é obrigatório.");
    }

    [Theory]
    [InlineData(0)]
    [InlineData(-10)]
    [InlineData(-0.01)]
    public void Constructor_InvalidAmount_ShouldThrowDomainException(decimal invalidAmount)
    {
        //Arrange
        var action = () => new Income("user-123", invalidAmount, "Lanche", DateTime.UtcNow);

        //Act & Assert
        action.Should().Throw<DomainException>()
            .WithMessage("O valor deve ser maior que zero.");
    }

    [Fact]
    public void Constructor_FutureDate_ShouldThrowDomainException()
    {
        //Arrange
        var futureDate = DateTime.UtcNow.AddDays(1);
        var action = () => new Income("user-123", 100m, "Freelance", futureDate);

        //Act & Assert
        action.Should().Throw<DomainException>()
            .WithMessage("A data não pode ser futura.");
    }
}