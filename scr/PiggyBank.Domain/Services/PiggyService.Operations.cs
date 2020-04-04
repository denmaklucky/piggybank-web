using PiggyBank.Common.Commands.Operations;
using PiggyBank.Common.Interfaces;
using PiggyBank.Common.Models.Dto;
using PiggyBank.Domain.Handler.Operations;
using PiggyBank.Domain.Queries.Operations;
using System;
using System.Threading.Tasks;

namespace PiggyBank.Domain.Services
{
    public partial class PiggyService : IOperationService
    {
        public Task AddExpenseOperation(AddOperationCommand command)
            => _handlerDispatcher.Invoke<AddExpenseOperationHandler, AddOperationCommand>(command);

        public Task AddIncomeOperation(AddOperationCommand command)
            => _handlerDispatcher.Invoke<AddIncomeOperationHandler, AddOperationCommand>(command);

        public Task<OperationDto> GetOperation(int id)
            => _queryDispatcher.Invoke<GetOperationByIdQuery, OperationDto>(id);

        public Task<OperationDto[]> GetOperations()
            => _queryDispatcher.Invoke<GetOperationsQuery, OperationDto[]>();

        public Task UpdateCategory(UpdateOperationCommand command)
        {
            throw new NotImplementedException();
        }
    }
}
