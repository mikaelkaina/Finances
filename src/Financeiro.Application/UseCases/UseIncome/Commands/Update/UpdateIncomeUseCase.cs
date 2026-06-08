using Financeiro.Domain.Interfaces;
using Financeiro.Domain.Interfaces.Repositories;
using Menso.Tools.Exceptions;

namespace Financeiro.Application.UseCases.UseIncome.Commands.Update;

public class UpdateIncomeUseCase
{
    private readonly IIncomeRepository _repository;
    private readonly IUnitOfWork _unitOfWork;

    public UpdateIncomeUseCase(IIncomeRepository repository, IUnitOfWork unitOfWork)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
    }

    public async Task ExecuteAsync(UpdateIncomeInput input)
    {
        var income = await _repository.GetByIdAsync(input.IncomeId);
        Throw.When.Null(income, ResourceIncome.ExpenseNotFound);

        income.UpdateIncome(input.Amount, input.Description, input.Date);
        await _unitOfWork.SaveChangesAsync();
    }
}
