using Financeiro.Application.DTOs.Income;
using Financeiro.Application.Interfaces.Repositories;

namespace Financeiro.Application.UseCases.UseIncome;

public class GetIncomesUseCase
{
    private readonly IIncomeRepository _repository;

    public GetIncomesUseCase(IIncomeRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<IncomeListItemOutput>> ExecuteAsync(string userId)
    {
        var incomes = await _repository.GetByUserAsync(userId);

        return incomes.Select(x => new IncomeListItemOutput(
            x.Id,
            x.Amount,
            x.Description,
            x.Date
        ));
    }
}
