using System.Linq;
using Microsoft.AspNetCore.Mvc;
using piggybank.dal.Contracts;

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
    }
}