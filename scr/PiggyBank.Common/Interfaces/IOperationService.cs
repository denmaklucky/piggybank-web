using PiggyBank.Common.Models.Dto;
using System.Threading.Tasks;

namespace PiggyBank.Common.Interfaces
{
    public interface IOperationService
    {
        /// <summary>
        /// Add a new operation
        /// </summary>
        Task AddOperation(AddCategoryCommand command);

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
        Task UpdateCategory(UpdateCategoryCommand command);
    }
}
