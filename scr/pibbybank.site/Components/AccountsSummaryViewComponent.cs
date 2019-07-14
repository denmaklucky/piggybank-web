using Microsoft.AspNetCore.Mvc;
using piggybank.dal.Contracts;
using piggybank.site.Models.ViewModel;
using System.Linq;

namespace piggybank.site.Components
{
    public class AccountsSummaryViewComponent : ViewComponent
    {
        private readonly IPBRepository _repository;
        public AccountsSummaryViewComponent(IPBRepository repository)
        {
            _repository = repository;
        }

        public IViewComponentResult Invoke()
        {
            var viewModel = new AccountsSummaryViewModel
            {
                Currency = "$",
                Summary = _repository.Accounts.Select(a => a.Balance).Sum()
            };
            return View(viewModel);
        }
    }
}
