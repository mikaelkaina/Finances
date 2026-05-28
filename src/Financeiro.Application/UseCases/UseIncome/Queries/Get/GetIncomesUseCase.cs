using Financeiro.Domain.Interfaces.Repositories;

namespace Financeiro.Application.UseCases.UseIncome.Queries.Get;

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
