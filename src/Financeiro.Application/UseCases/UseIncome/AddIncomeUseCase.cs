using Financeiro.Application.DTOs.Income;
using Financeiro.Application.Interfaces;
using Financeiro.Application.Interfaces.Repositories;
using Financeiro.Domain.Entities;

namespace Financeiro.Application.UseCases.UseIncome;

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
            input.Date);

        await _repository.AddAsync(income);
        await _unitOfWork.SaveChangesAsync();
    }
}
