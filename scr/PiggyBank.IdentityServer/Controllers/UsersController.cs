using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PiggyBank.IdentityServer.Dto;
using System.Threading;
using System.Threading.Tasks;

namespace PiggyBank.IdentityServer.Controllers
{
    [ApiController, Route("[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly UserManager<IdentityUser> _userManager;
        public UsersController(UserManager<IdentityUser> userManager)
            => _userManager = userManager;

        [HttpPost]
        public async Task<IActionResult> Post(UserDto request, CancellationToken token)
        {
            await Task.Delay(100);
            return Ok();
        }
    }
}
