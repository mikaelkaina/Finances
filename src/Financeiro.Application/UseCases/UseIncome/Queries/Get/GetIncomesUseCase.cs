using Financeiro.Application.Interfaces.Repositories;
using Financeiro.Application.UseCases.UseIncome.Queries.Get;

namespace Financeiro.Application.UseCases.UseIncome.Queries;

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

        return incomes.Select(I => new IncomeListItemOutput(
            I.Id,
            I.Amount,
            I.Description,
            I.Date
        ));
    }
}
