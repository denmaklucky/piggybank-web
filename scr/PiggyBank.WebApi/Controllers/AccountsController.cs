using Microsoft.AspNetCore.Mvc;
using PiggyBank.Common.Interfaces;
using PiggyBank.Common.Models.ReturnModels;
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
    }
}
