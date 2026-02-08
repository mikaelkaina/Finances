using Financeiro.Application.DTOs.Income;
using Financeiro.Application.Interfaces.Repositories;
using Financeiro.Domain.Entities;

namespace Financeiro.Application.UseCases.UseIncome;

public class AddIncomeUseCase
{
    private readonly IIncomeRepository _repository;

    public AddIncomeUseCase(IIncomeRepository repository)
    {
        _repository = repository;
    }

    public async Task ExecuteAsync(AddIncomeInput input)
    {
        var income = new Income(
            input.UserId,
            input.Amount,
            input.Description,
            input.Date);

        await _repository.AddAsync(income);
    }
}
