using Microsoft.AspNetCore.Mvc;
using PiggyBank.Common.Commands.Accounts;
using PiggyBank.Common.Interfaces;
using PiggyBank.Common.Models.Dto;
using System.Threading;
using System.Threading.Tasks;

namespace PiggyBank.WebApi.Controllers
{
    [ApiController, Route("api/[controller]")]
    public class AccountsController : ControllerBase
    {
        private readonly IAccountService _service;

        public AccountsController(IAccountService service)
            => _service = service;

        [HttpGet]
        public Task<AccountInfoDto[]> Get(CancellationToken token)
            => _service.GetAccounts();

        [HttpPost]
        public async Task<IActionResult> Post(AccountDto request, CancellationToken token)
        {
            var command = new AddAccountCommand
            {
                Balance = request.Balance,
                Currency = request.Currency,
                IsArchived = request.IsArchived,
                IsDeleted = request.IsDeleted,
                Title = request.Title,
                Type = request.Type
            };

            await _service.AddAccount(command);

            return Ok();
        }

        [HttpPatch, Route("{accountId}/update")]
        public async Task<IActionResult> Update(int accountId, AccountDto request, CancellationToken token)
        {
            var command = new UpdateAccountCommand
            {
                Balance = request.Balance,
                Currency = request.Currency,
                Id = request.Id,
                Title = request.Title,
                Type = request.Type
            };

            await _service.UpdateAccount(command);

            return Ok();
        }

        [HttpGet, Route("{accountId}")]
        public Task<AccountDto> GetById(int accountId, CancellationToken token)
            => _service.GetAccount(accountId);

        [HttpDelete, Route("{accountId}/delete")]
        public async Task<IActionResult> Delete(int accountId, CancellationToken token)
        {
            await _service.DeleteAccount(accountId);
            return Ok();
        }

        [HttpPatch, Route("{accountId}/archive")]
        public async Task<IActionResult> Archive(int accountId, CancellationToken token)
        {
            await _service.ArchiveAccount(accountId);
            return Ok();
        }
    }
}
