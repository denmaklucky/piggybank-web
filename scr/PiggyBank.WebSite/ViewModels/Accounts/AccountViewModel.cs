using Microsoft.AspNetCore.Components;
using PiggyBank.Common.Commands.Accounts;
using PiggyBank.Common.Enums;
using PiggyBank.Common.Interfaces;
using PiggyBank.Common.Models.ReturnModels;
using System;
using System.Threading.Tasks;

namespace PiggyBank.WebSite.ViewModels.Accounts
{
    public class AccountViewModel : ComponentBase
    {
        [Parameter]
        public int AccountId { get; set; }

        [Inject]
        public IAccountService AccountService { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        public AccountDto Model { get; set; }

        public async Task OnSave()
        {
            if (AccountId != default)
            {
                await AccountService.UpdateAccountCommand(new UpdateAccountCommand
                {
                    Balance = Model.Balance,
                    Currency = Model.Currency,
                    Id = Model.Id,
                    IsArchived = Model.IsArchived,
                    IsDeleted = Model.IsDeleted,
                    Title = Model.Title,
                    Type = Model.Type
                });
            }
            else
            {
                await AccountService.AddAccount(new AddAccountCommand
                {
                    Balance = Model.Balance,
                    Currency = Model.Currency,
                    IsArchived = Model.IsArchived,
                    IsDeleted = Model.IsDeleted,
                    Title = Model.Title,
                    Type = Model.Type
                });
            }

            OnGoBack();
        }

        public void OnGoBack() => NavigationManager.NavigateTo("/accounts");

        public void OnTypeChanged(ChangeEventArgs args)
        {
            Model.Type = (AccountType)Enum.Parse(typeof(AccountType), (string)args.Value);
        }

        protected override async Task OnInitializedAsync()
        {
            if (AccountId != default)
            {
                Model = await AccountService.GetAccount(AccountId);
                return;
            }

            Model = new AccountDto();
        }
    }
}
