using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PiggyBank.Common.Models.ReturnModels;
using PiggyBank.Model;
using PiggyBank.Model.Models;

namespace PiggyBank.Domain.Queries.Accounts
{
    public class GetAccountsQuery : BaseQuery<AccountInfoDto[]>
    {
        public GetAccountsQuery(PiggyContext context) : base(context) {}

        public override Task<AccountInfoDto[]> Invoke()
            => GetRepository<Account>().Select(a => new AccountInfoDto
            {
                Id = a.Id,
                Type = a.Type,
                Balance = a.Balance,
                Currency = a.Currency,
                Title = a.Title,
            }).ToArrayAsync();
    }
}
