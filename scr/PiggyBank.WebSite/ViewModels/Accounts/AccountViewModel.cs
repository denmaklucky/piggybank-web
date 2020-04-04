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
        [Inject]
        public IAccountService AccountService { get; set; }

        [Parameter]
        public EventCallback<EventArgs> GoBack { get; set; }

        [Parameter]
        public AccountInfoDto Model { get; set; }

        public async Task OnSave()
        {
            if (Model.Id != default)
            {
                await AccountService.UpdateAccount(new UpdateAccountCommand
                {
                    Balance = Model.Balance,
                    Currency = Model.Currency,
                    Id = Model.Id,
                    //IsArchived = Model.IsArchived,
                    //IsDeleted = Model.IsDeleted,
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
                    //IsArchived = Model.IsArchived,
                    //IsDeleted = Model.IsDeleted,
                    Title = Model.Title,
                    Type = Model.Type
                });
            }

            await OnGoBack();
        }

        public Task OnGoBack() => GoBack.InvokeAsync(EventArgs.Empty);

        public void OnTypeChanged(ChangeEventArgs args)
        {
            Model.Type = (AccountType)Enum.Parse(typeof(AccountType), (string)args.Value);
        }
    }
}
