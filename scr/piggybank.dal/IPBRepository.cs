using piggybank.dal.Dto;
using System.Linq;
using System.Threading.Tasks;

namespace piggybank.dal.Contracts
{
    public interface IPBRepository
    {
        Task<bool> AddOrUpdateCategory(CategoryDto category);

        IQueryable<TransactionDto> Transactions { get; }

        IQueryable<AccountDto> Accounts { get; }

        IQueryable<CategoryDto> Categories { get; }
    }
}
