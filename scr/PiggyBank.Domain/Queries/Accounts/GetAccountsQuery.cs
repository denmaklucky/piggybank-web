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
                Balance = a.Balance,
                Currency = a.Currency,
                Id = a.Id,
                IsArchived = a.IsArchived,
                IsDeleted = a.IsDeleted,
                Title = a.Title,
                Type = a.Type
            }).ToArrayAsync();
    }
}
