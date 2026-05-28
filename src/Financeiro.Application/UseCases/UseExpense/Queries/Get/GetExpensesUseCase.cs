using Financeiro.Application.Interfaces.Repositories;

namespace Financeiro.Application.UseCases.UseExpense.Queries.Get;

public class GetExpensesUseCase
{
    private readonly IExpenseRepository _repository;
    public GetExpensesUseCase(IExpenseRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<ExpenseListItemOutput?>> ExecuteAsync(string userId)
    {
        var expenses = await _repository.GetByUserAsync(userId);

        return expenses.Select(e => new ExpenseListItemOutput(
            e.Id,
            e.Amount,
            e.Description,
            e.Date
        ));
    }
}
