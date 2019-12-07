using PiggyBank.Model;
using PiggyBank.Model.Interfaces;
using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace PiggyBank.Domain.Handler
{
    public abstract class BaseHandler<TCommand> : IDisposable
    {
        private readonly PiggyContext _context;

        public TCommand Command { get; set; }

        protected BaseHandler(PiggyContext context, TCommand command)
        {
            _context = context;
            Command = command;
        }

        public DbSet<T> GetRepository<T>() where T : class, IBaseModel
        => _context.Set<T>();

        public abstract Task Invoke();

        public void Dispose()
        {
            _context?.Dispose();
        }
    }
}
