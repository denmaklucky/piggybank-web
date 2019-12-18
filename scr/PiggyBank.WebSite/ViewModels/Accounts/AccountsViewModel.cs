using Microsoft.AspNetCore.Components;
using PiggyBank.Common.Interfaces;
using PiggyBank.Common.Models.ReturnModels;
using System.Threading.Tasks;

namespace PiggyBank.WebSite.ViewModels.Accounts
{
    public class AccountsViewModel : ComponentBase
    {
        [Inject]
        public IPiggyService PiggyService { get; set; }

        public AccountDto[] Accounts { get; set; }

        protected override async Task OnInitializedAsync()
        {
            Accounts = await PiggyService.GetAccounts();
        }
    }
}
