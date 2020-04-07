using Microsoft.EntityFrameworkCore;
using PiggyBank.Common.Commands.Operations;
using PiggyBank.Common.Enums;
using PiggyBank.Domain.Handler.Operations;
using PiggyBank.Model;
using PiggyBank.Model.Models.Entities;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace PiggyBank.Test.Handlers.Operations
{
    public class AddBudgetOperationHandlerTest
    {
        private readonly PiggyContext _context;
        public AddBudgetOperationHandlerTest()
        {
            _context = new PiggyContext(new DbContextOptionsBuilder<PiggyContext>()
                .UseInMemoryDatabase(databaseName: "PiggyBank_InMemory")
                .Options);
        }

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
            Assert.ThrowsAsync(handler.Invoke());
        }
    }
}
