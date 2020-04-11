using Microsoft.EntityFrameworkCore;
using PiggyBank.Common.Commands.Operations;
using PiggyBank.Common.Enums;
using PiggyBank.Domain.Handler.Operations;
using PiggyBank.Model;
using PiggyBank.Model.Models.Entities;
using System;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace PiggyBank.Test.Handlers.Operations
{
    public class AddBudgetOperationHandlerTest : IDisposable
    {
        private readonly PiggyContext _context;
        public AddBudgetOperationHandlerTest()
            => _context = new PiggyContext(new DbContextOptionsBuilder<PiggyContext>()
                .UseInMemoryDatabase(databaseName: "PiggyBank_InMemory").Options);

        [Fact]
        public async Task Invoke_OperationIsValid_OperationWasAdded()
        {
            var addOperaion = new AddBudgetOperationCommand
            {
                AccountId = 1,
                Amount = 100,
                CategoryId = 1,
                Comment = "Hello, world",
                Type = OperationType.Budget
            };

            _context.Accounts.Add(new Account
            {
                Id = 1,
                Balance = 0
            });

            _context.Categories.Add(new Category
            {
                Id = 1
            });

            _context.SaveChanges();

            var handler = new AddBudgetOperationHandler(_context, addOperaion);
            await handler.Invoke();
            _context.SaveChanges();

            var operation = _context.BudgetOperations.First();

            Assert.Equal(OperationType.Budget, operation.Type);
            Assert.Equal(100, operation.Amount);
        }

        [Fact]
        public async Task Invoke_AccountIdNotValid_ThrowsException()
        {
            var addOperaion = new AddBudgetOperationCommand
            {
                AccountId = 1,
                Amount = 100,
                CategoryId = 1,
                Comment = "Hello, world",
                Type = OperationType.Budget
            };

            var handler = new AddBudgetOperationHandler(_context, addOperaion);
            await Assert.ThrowsAsync<ArgumentException>(() => handler.Invoke());
        }

        [Fact]
        public async Task Invoke_CategoryIdNotValid_ThrowsException()
        {
            var addOperaion = new AddBudgetOperationCommand
            {
                AccountId = 1,
                Amount = 100,
                CategoryId = 1,
                Comment = "Hello, world",
                Type = OperationType.Budget
            };

            _context.Accounts.Add(new Account
            {
                Id = 1,
                Balance = 0
            });

            _context.SaveChanges();
            var handler = new AddBudgetOperationHandler(_context, addOperaion);

            await Assert.ThrowsAsync<ArgumentException>(() => handler.Invoke());
        }

        [Fact]
        public async Task Invoke_WhenCallWithIncomeCategory_BalancePluse()
        {
            var addOperaion = new AddBudgetOperationCommand
            {
                AccountId = 1,
                Amount = 100,
                CategoryId = 1,
                Comment = "Hello, world",
                Type = OperationType.Budget
            };

            var account = new Account
            {
                Id = 1,
                Balance = 0
            };

            _context.Accounts.Add(account);

            _context.Categories.Add(new Category
            {
                Id = 1,
                Type = CategoryType.Income
            });

            _context.SaveChanges();
            var handler = new AddBudgetOperationHandler(_context, addOperaion);
            await handler.Invoke();

            Assert.Equal(100, account.Balance);
        }

        [Fact]
        public async Task Invoke_WhenCallWithExpenseCategory_BalanceMinus()
        {
            var addOperaion = new AddBudgetOperationCommand
            {
                AccountId = 1,
                Amount = 100,
                CategoryId = 1,
                Comment = "Hello, world",
                Type = OperationType.Budget
            };

            var account = new Account
            {
                Id = 1,
                Balance = 0
            };

            _context.Accounts.Add(account);

            _context.Categories.Add(new Category
            {
                Id = 1,
                Type = CategoryType.Expense
            });

            _context.SaveChanges();
            var handler = new AddBudgetOperationHandler(_context, addOperaion);
            await handler.Invoke();

            Assert.Equal(-100, account.Balance);
        }

        public void Dispose()
        {
            _context.Accounts.RemoveRange(_context.Accounts);
            _context.Categories.RemoveRange(_context.Categories);
            _context.Operations.RemoveRange(_context.Operations);
            _context.SaveChanges();
            _context.Dispose();
        }
    }
}
