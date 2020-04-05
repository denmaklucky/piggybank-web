using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PiggyBank.Common.Models.Dto;
using PiggyBank.Model;
using PiggyBank.Model.Models.Entities;

namespace PiggyBank.Domain.Queries.Accounts
{
    public class GetAccountsQuery : BaseQuery<AccountInfoDto[]>
    {
        public GetAccountsQuery(PiggyContext context) : base(context) { }

        public override Task<AccountInfoDto[]> Invoke()
            => GetRepository<Account>().Where(a => !a.IsDeleted).Select(a => new AccountInfoDto
            {
                Id = a.Id,
                Type = a.Type,
                Balance = a.Balance,
                Currency = a.Currency,
                Title = a.Title,
            }).ToArrayAsync();
    }
}
