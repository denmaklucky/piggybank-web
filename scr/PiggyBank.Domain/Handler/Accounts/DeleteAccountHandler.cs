﻿using Microsoft.EntityFrameworkCore;
using PiggyBank.Model;
using PiggyBank.Model.Models.Entities;
using System.Threading.Tasks;

namespace PiggyBank.Domain.Handler.Accounts
{
    public class DeleteAccountHandler : BaseHandler<int>
    {
        public DeleteAccountHandler(PiggyContext context, int command)
            : base(context, command) { }

        public override async Task Invoke()
        {
            var repository = GetRepository<Account>();
            var account = await repository
                .FirstOrDefaultAsync(a => a.Id == Command && !a.IsDeleted);

            if (account == null)
                return;

            account.IsDeleted = true;

            repository.Update(account);
        }
    }
}
