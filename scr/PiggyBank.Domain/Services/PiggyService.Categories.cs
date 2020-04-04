using PiggyBank.Common.Commands.Categories;
using PiggyBank.Common.Interfaces;
using PiggyBank.Common.Models.Dto;
using PiggyBank.Domain.Handler.Categories;
using PiggyBank.Domain.Queries.Categories;
using System.Threading.Tasks;

namespace PiggyBank.Domain.Services
{
    public partial class PiggyService : ICategoryService
    {
        public Task AddCategory(AddCategoryCommand command)
            => _handlerDispatcher.Invoke<AddCategoryHandler, AddCategoryCommand>(command);

        public Task ArchiveCategory(int id)
            => _handlerDispatcher.Invoke<ArchiveCategoryHandler, int>(id);

        public Task DeleteCategory(int id)
            => _handlerDispatcher.Invoke<DeleteCategoryHandler, int>(id);

        public Task<CategoryDto[]> GetCategories()
            => _queryDispatcher.Invoke<GetCategoriesQuery, CategoryDto[]>();

        public Task<CategoryDto> GetCategory(int id)
            => _queryDispatcher.Invoke<GetCategoryByIdQuery, CategoryDto>(id);

        public Task UpdateCategory(UpdateCategoryCommand command)
            => _handlerDispatcher.Invoke<UpdateCategoryHandler, UpdateCategoryCommand>(command);
    }
}
