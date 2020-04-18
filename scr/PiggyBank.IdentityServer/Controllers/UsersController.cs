using Microsoft.AspNetCore.Mvc;
using PiggyBank.IdentityServer.Dto;
using System.Threading;
using System.Threading.Tasks;

namespace PiggyBank.IdentityServer.Controllers
{
    [ApiController, Route("[controller]")]
    public class UsersController : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> Post(UserDto request, CancellationToken token)
        {
            await Task.Delay(100);
            return Ok();
        }
    }
}
