using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PiggyBank.Domain.Handler;
using PiggyBank.Model;
using PiggyBank.Model.Interfaces;
using PiggyBank.Model.Models;
using Xunit;

namespace PiggyBank.Test.Handlers
{
    public class BaseHandlerTest
    {
        private readonly DbContextOptions<PiggyContext> _options;

        public BaseHandlerTest()
        {
            _options = new DbContextOptionsBuilder<PiggyContext>()
                .UseInMemoryDatabase(databaseName: "PiggyBank_InMemory")
                .Options;
        }

        [Fact]
        public void GetRepositoryOkTest()
        {
            using (var handler = new TestHandler(new object(), new PiggyContext(_options)))
            {
                var repository = handler.GetRepository<Transaction>();
                Assert.NotNull(repository);
            }
        }

        [Fact]
        public void GetRepositoryExceptionTest()
        {
            using (var handler = new TestHandler(new object(), new PiggyContext(_options)))
            {
                var temp = handler.GetRepository<TestModel>();
                Assert.Throws<InvalidOperationException>(() => { temp.CountAsync(); });
            }
        }
    }

    public class TestHandler : BaseHandler<object>
    {
        public TestHandler(object obj, PiggyContext context) : base(context, obj) { }
        public override Task Invoke()
        {
            throw new NotImplementedException();
        }
    }

    public class TestModel : IBaseModel
    {
        public int Id { get; set; }
    }
}
