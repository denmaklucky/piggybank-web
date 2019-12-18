using PiggyBank.Common.Models.ReturnModels;
using PiggyBank.Model;
using System;
using System.Threading.Tasks;

namespace PiggyBank.Domain.Queries.Accounts
{
    public class GetAccountByIdQuery : BaseQuery<AccountDto1>
    {
        public GetAccountByIdQuery(PiggyContext context) : base(context)
        {
        }

        public override Task<AccountDto1> Invoke()
        {
            throw new NotImplementedException();
        }
    }
}
