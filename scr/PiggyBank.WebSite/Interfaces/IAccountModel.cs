using PiggyBank.Common.Models.Dto;
using System.Threading.Tasks;

namespace PiggyBank.WebSite.Interfaces
{
    public interface IAccountModel
    {
        Task<AccountInfoDto[]> GetAccounts();

        Task AddAccount(AccountDto account);

        Task UpdateAccount(AccountDto account);
    }
}
