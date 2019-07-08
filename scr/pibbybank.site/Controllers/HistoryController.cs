using Microsoft.AspNetCore.Mvc;
using piggybank.dal.Contracts;
using piggybank.site.Models.ViewModel;
using System.Linq;

namespace pibbybank.site.Controllers
{
    public class HistoryController : Controller
    {
        private IPBRepository _repository;
        public HistoryController(IPBRepository repository)
        {
            _repository = repository;
        }
        public IActionResult Index()
        {
            var transactionsInDay = _repository.Transactions
                .GroupBy(t => t.CreatedOn.Date)
                .Select(td => new TransactionsOfDay
                {
                    Date = td.Key,
                    Transactions = td.ToList()
                });

            return View(new HistoryViewModel { TransactionsInDay = transactionsInDay });
        }
    }
}