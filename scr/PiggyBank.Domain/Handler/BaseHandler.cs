using PiggyBank.Model;
using PiggyBank.Model.Interfaces;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace PiggyBank.Domain.Handler
{
    public abstract class BaseHandler<TCommand> : IDisposable
    {
        private readonly PiggyContext _context;

        public TCommand Command { get; set; }

        protected BaseHandler(PiggyContext context)
            => _context = context;

        public IQueryable<T> GetRepository<T>() where T : class, IBaseModel
        => _context.Set<T>();

        public abstract Task Invoke();

        public void Dispose()
        {
            _context?.Dispose();
        }
    }
}
