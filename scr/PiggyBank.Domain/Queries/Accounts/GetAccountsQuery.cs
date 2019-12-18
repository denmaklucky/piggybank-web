using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PiggyBank.Common.Models.ReturnModels;
using PiggyBank.Model;
using PiggyBank.Model.Models;

namespace PiggyBank.Domain.Queries.Accounts
{
    public class GetAccountsQuery : BaseQuery<AccountDto[]>
    {
        public GetAccountsQuery(PiggyContext context) : base(context) {}

        public override Task<AccountDto[]> Invoke()
            => GetRepository<Account>().Select(a => new AccountDto
            {
                Id = a.Id,
                Balance = a.Balance,
                Currency = a.Currency,
                Title = a.Title,
            }).ToArrayAsync();
    }
}
