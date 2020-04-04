using PiggyBank.Common.Commands.Categories;
using PiggyBank.Common.Models.Dto;
using System.Threading.Tasks;

namespace PiggyBank.Common.Interfaces
{
    public interface ICategoryService
    {
        /// <summary>
        /// Add a new category
        /// </summary>
        Task AddCategory(AddCategoryCommand command);

        /// <summary>
        /// Get categories
        /// </summary>
        Task<CategoryDto[]> GetCategories();

        /// <summary>
        /// Get category by id
        /// </summary>
        Task<CategoryDto> GetCategory(int id);

        /// <summary>
        /// Update exists entity
        /// </summary>
        Task UpdateCategory(UpdateCategoryCommand command);

        /// <summary>
        /// Delete exists entity
        /// </summary>
        Task DeleteCategory(int id);

        /// <summary>
        /// Archive exists entity
        /// </summary>
        Task ArchiveCategory(int id);
    }
}
