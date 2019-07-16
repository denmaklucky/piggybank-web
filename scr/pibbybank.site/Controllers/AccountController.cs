using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using piggybank.dal.Contracts;
using piggybank.dal.Dto;
using piggybank.site.Models.ViewModel;

namespace piggybank.site.Controllers
{
    public class AccountController : Controller
    {
        private readonly IPBRepository _repository;
        public AccountController(IPBRepository repository)
        {
            _repository = repository;
        }

        public IActionResult Index() => View(_repository.Accounts.ToList());

        public IActionResult Create() => View("EditAccount", new AccountViewModel());

        [HttpPost]
        public async Task<IActionResult> Edit(AccountViewModel account)
        {
            if (ModelState.IsValid)
            {
                var accountDto = new AccountDto
                {
                    Id = account.Id,
                    Title = account.Title,
                    Currency = account.Currency,
                    Balance = account.Balance,
                    Type = account.Type,
                    IsArchived = account.IsArchived,
                    IsDeleted = account.IsDeleted
                };
                TempData["msg"] = $"{account.Title} has been saved";
                await _repository.AddOrUpdateAccount(accountDto);
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View("EditAccount", account);
            }
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var accountDto = _repository.Accounts.FirstOrDefault(a => a.Id == id);
            if(accountDto != null)
            {
                var account = new AccountViewModel
                {
                    Id = accountDto.Id,
                    Title = accountDto.Title,
                    Currency = accountDto.Currency,
                    Balance = accountDto.Balance,
                    Type = accountDto.Type,
                    IsArchived = accountDto.IsArchived,
                    IsDeleted = accountDto.IsDeleted
                };

                return View("EditAccount", account);
            }
            return BadRequest();
        }
    }
}