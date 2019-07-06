using Microsoft.AspNetCore.Mvc;
using piggybank.dal.Contracts;

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
            return View(_repository.Transactions) ;
        }
    }
}