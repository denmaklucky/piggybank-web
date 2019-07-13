using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using piggybank.dal.Contracts;
using piggybank.dal.Dto;
using piggybank.site.Models.ViewModel;

namespace piggybank.site.Controllers
{
    public class CategoryController : Controller
    {
        private readonly IPBRepository _repository;
        public CategoryController(IPBRepository repository)
        {
            _repository = repository;
        }

        public IActionResult Index()
        {
            return View(_repository.Categories.ToList());
        }

        public IActionResult Create() => View("EditCategory", new CategoryViewModel());

        [HttpPost]
        public async Task<IActionResult> Edit(CategoryViewModel category)
        {
            if (ModelState.IsValid)
            {
                var categoryDto = new CategoryDto
                {
                    Title = category.Title,
                    Type = category.CategoryType,
                    IsRequired = category.IsDeleted,
                    HexColor = "#FB3232",
                    Id = category.Id
                };
                await _repository.AddOrUpdateCategory(categoryDto);
                TempData["msg_category"] = $"{category.Title} has been created";
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View("EditCategory", category);
            }
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var category = _repository.Categories.FirstOrDefault(c => c.Id == id);

            return View("EditCategory", new CategoryViewModel
            {
                Title = category.Title,
                HexColor = category.HexColor,
                CategoryType = category.Type,
                IsRequired = category.IsRequired
            });
        }
    }
}