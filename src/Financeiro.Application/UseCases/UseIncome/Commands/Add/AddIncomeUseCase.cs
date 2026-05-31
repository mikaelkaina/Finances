using Financeiro.Domain.Entities;
using Financeiro.Domain.Interfaces;
using Financeiro.Domain.Interfaces.Repositories;

namespace Financeiro.Application.UseCases.UseIncome.Commands.Add;

public class AddIncomeUseCase
{
    private readonly IIncomeRepository _repository;
    private readonly IUnitOfWork _unitOfWork;

    public AddIncomeUseCase(IIncomeRepository repository, IUnitOfWork unitOfWork)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
    }

    public async Task ExecuteAsync(AddIncomeInput input)
    {
        var income = new Income(
            input.UserId,
            input.Amount,
            input.Description,
            input.Date
        );
        
        _repository.Add(income);
        await _unitOfWork.SaveChangesAsync();
    }
}
