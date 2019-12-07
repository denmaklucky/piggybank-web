using System.Threading.Tasks;
using PiggyBank.Common.Commands.Accounts;

namespace PiggyBank.Common.Interfaces
{
    public interface IPiggyService
    {
        Task AddAccount(AddAccountCommand command);
    }
}
