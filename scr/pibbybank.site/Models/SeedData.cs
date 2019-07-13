using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using piggybank.common.Enums;
using piggybank.dal;
using piggybank.dal.Models;
using System;
using System.Linq;

namespace piggybank.site.Models
{
    public static class SeedData
    {
        public static async void EnsurePopulated(IApplicationBuilder app)
        {
            var context = app.ApplicationServices.GetRequiredService<PiggyContext>();
            context.Database.Migrate();

            if (!context.Categories.Any())
            {
                context.Categories.Add(new Category
                {
                    Title = "Products",
                    Type = CategoryType.Expense,
                    IsDeleted = false,
                    IsRequired = true,
                    CreatedOn = DateTime.Now,
                    HexColor = "#FFFFB900"
                });
                context.Categories.Add(new Category
                {
                    Title = "Salary",
                    Type = CategoryType.Income,
                    IsDeleted = false,
                    IsRequired = true,
                    CreatedOn = DateTime.Now,
                    HexColor = "#FFFF8C00"
                });
            }

            if (!context.Accounts.Any())
            {
                context.Accounts.Add(new dal.Models.Account
                {
                    Balance = 180000,
                    CreatedOn = DateTime.Now,
                    Currency = "$",
                    IsArchived = false,
                    IsDeleted = false,
                    Title = "LimeCredit",
                    Type = AccountType.Card
                });
            }

            if (!context.Transactions.Any())
            {
                context.Transactions.Add(new dal.Models.Transaction
                {
                    AccountId = 1,
                    CategoryId = 1,
                    Amount = 2000,
                    Comment = "Buy in Spar",
                    CreatedOn = DateTime.Now,
                    Type = TransactionType.Expense
                });

                context.Transactions.Add(new dal.Models.Transaction
                {
                    AccountId = 1,
                    CategoryId = 1,
                    Amount = 1400,
                    Comment = "Buy in Spar",
                    CreatedOn = DateTime.Now,
                    Type = TransactionType.Expense
                });

                context.Transactions.Add(new dal.Models.Transaction
                {
                    AccountId = 1,
                    CategoryId = 2,
                    Amount = 2000,
                    CreatedOn = DateTime.Now,
                    Type = TransactionType.Income
                });
            }

            await context.SaveChangesAsync();
        }
    }
}
