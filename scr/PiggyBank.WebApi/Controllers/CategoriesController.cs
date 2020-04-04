using Microsoft.AspNetCore.Mvc;
using PiggyBank.Common.Commands.Categories;
using PiggyBank.Common.Interfaces;
using PiggyBank.Common.Models.Dto;
using System.Threading;
using System.Threading.Tasks;

namespace PiggyBank.WebApi.Controllers
{
    [ApiController, Route("api/[controller]")]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _service;

        public CategoriesController(ICategoryService service)
            => _service = service;

        [HttpGet]
        public Task<CategoryDto[]> Get(CancellationToken token)
            => _service.GetCategories();

        [HttpGet, Route("{categoryId}")]
        public Task<CategoryDto> GetById(int categoryId, CancellationToken token)
            => _service.GetCategory(categoryId);

        [HttpPost]
        public async Task<IActionResult> Post(CategoryDto request, CancellationToken token)
        {
            var command = new AddCategoryCommand
            {
                Title = request.Title,
                HexColor = request.HexColor,
                Type = request.Type
            };

            await _service.AddCategory(command);
            return Ok();
        }

        [HttpPatch, Route("{categoryId}/update")]
        public async Task<IActionResult> Update(int categoryId, CategoryDto request, CancellationToken token)
        {
            var command = new UpdateCategoryCommand
            {
                Id = request.Id,
                Title = request.Title,
                Type = request.Type,
                HexColor = request.HexColor
            };

            await _service.UpdateCategory(command);

            return Ok();
        }

        [HttpDelete, Route("{categoryId}/delete")]
        public async Task<IActionResult> Delete(int categoryId, CancellationToken token)
        {
            await _service.DeleteCategory(categoryId);
            return Ok();
        }

        [HttpPatch, Route("{categoryId}/archive")]
        public async Task<IActionResult> Archive(int categoryId, CancellationToken token)
        {
            await _service.ArchiveCategory(categoryId);
            return Ok();
        }
    }
}
