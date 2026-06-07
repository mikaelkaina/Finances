using Financeiro.Domain.Interfaces;
using Financeiro.Domain.Exceptions;
using Financeiro.Domain.Interfaces.Repositories;
using Menso.Tools.Exceptions;

namespace Financeiro.Application.UseCases.UseIncome.Commands.Delete;

public class DeleteIncomeUseCase
{
    private readonly IIncomeRepository _repository;
    private readonly IUnitOfWork _unitOfWork;

    public DeleteIncomeUseCase(IIncomeRepository repository, IUnitOfWork unitOfWork)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
    }

    public async Task ExecuteAsync(DeleteIncomeInput input)
    {
        var income = await _repository.GetByIdAsync(input.IncomeId);
        Throw.When.Null(income, ResourceIncome.ExpenseNotFound);

        _repository.Remove(income);
        await _unitOfWork.SaveChangesAsync();
    }
}
