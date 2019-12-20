using Microsoft.EntityFrameworkCore;
using PiggyBank.Common.Enums;
using PiggyBank.Common.Models.Generic;
using PiggyBank.Common.Models.ReturnModels;
using PiggyBank.Model;
using PiggyBank.Model.Models;
using System.Linq;
using System.Threading.Tasks;

namespace PiggyBank.Domain.Queries.Accounts
{
    public class GetAccountsGroupByTypeQuery : BaseQuery<GenericGroup<AccountType, AccountDto>[]>
    {
        public GetAccountsGroupByTypeQuery(PiggyContext context) : base(context) { }

        public override Task<GenericGroup<AccountType, AccountDto>[]> Invoke()
            => GetRepository<Account>().GroupBy(a => a.Type)
            .Select(a => new GenericGroup<AccountType, AccountDto>
            {
                Key = a.Key,
                Values = a.Select(x => new AccountDto
                {
                    Balance = x.Balance,
                    Currency = x.Currency,
                    Id = x.Id,
                    Title = x.Title,
                    Type = x.Type
                }).ToArray()
            }).ToArrayAsync();
    }
}
