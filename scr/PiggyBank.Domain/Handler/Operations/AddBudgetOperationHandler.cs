﻿using Microsoft.EntityFrameworkCore;
using PiggyBank.Common.Commands.Operations;
using PiggyBank.Common.Enums;
using PiggyBank.Model;
using PiggyBank.Model.Models.Entities;
using System;
using System.Threading.Tasks;

namespace PiggyBank.Domain.Handler.Operations
{
    public class AddBudgetOperationHandler : BaseHandler<AddBudgetOperationCommand>
    {
        public AddBudgetOperationHandler(PiggyContext context, AddBudgetOperationCommand command)
            : base(context, command) { }

        public override async Task Invoke()
        {
            var accountRepository = GetRepository<Account>();
            var account = await accountRepository.FirstOrDefaultAsync(a => a.Id == Command.AccountId && !a.IsDeleted)
                ?? throw new ArgumentException($"Can't found account by {Command.AccountId}");

            var category = await GetRepository<Category>().FirstOrDefaultAsync(c => c.Id == Command.CategoryId && !c.IsDeleted)
                ?? throw new ArgumentException($"Can't found category by {Command.CategoryId}");

            var operation = new BudgetOperation
            {
                Amount = Command.Amount,
                Type = Command.Type,
                Comment = Command.Comment,
                AccountId = Command.AccountId,
                CategoryId = Command.CategoryId
            };

            account.ChangeBalance(category.Type == CategoryType.Income ? operation.Amount : -operation.Amount);

            accountRepository.Update(account);

            GetRepository<BudgetOperation>().Add(operation);
        }
    }
}
