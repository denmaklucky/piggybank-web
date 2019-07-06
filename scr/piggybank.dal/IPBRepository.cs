using piggybank.dal.DTO;
using System.Linq;

namespace piggybank.dal.Contracts
{
    public interface IPBRepository
    {
        IQueryable<TransactionDto> Transactions { get; }

        IQueryable<AccountDto> Accounts { get; }

        IQueryable<CategoryDto> Categories { get; }
    }
}
