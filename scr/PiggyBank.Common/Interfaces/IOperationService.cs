using PiggyBank.Common.Commands.Operations;
using PiggyBank.Common.Models.Dto;
using System.Threading.Tasks;

namespace PiggyBank.Common.Interfaces
{
    public interface IOperationService
    {
        /// <summary>
        /// Add a new income operation
        /// </summary>
        Task AddIncomeOperation(AddOperationCommand command);

        /// <summary>
        /// Add a new expense operation
        /// </summary>
        Task AddExpenseOperation(AddOperationCommand command);

        /// <summary>
        /// Get operations
        /// </summary>
        Task<OperationDto[]> GetOperations();

        /// <summary>
        /// Get operation by id
        /// </summary>
        Task<OperationDto> GetOperation(int id);

        /// <summary>
        /// Update exists entity
        /// </summary>
        Task UpdateCategory(UpdateOperationCommand command);
    }
}
