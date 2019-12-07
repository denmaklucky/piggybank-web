using System;
using System.Threading.Tasks;
using PiggyBank.Domain.Handler;
using PiggyBank.Model;

namespace PiggyBank.Domain.Infrastructure
{
    public class HandlerDispatcher
    {
        private readonly PiggyContext _context;

        public HandlerDispatcher(PiggyContext context)
            => _context = context;

        public async Task Invoke<THandler, TCommand>() where THandler : BaseHandler<TCommand>
        {
            var handler = (BaseHandler<TCommand>)Activator.CreateInstance(typeof(THandler), _context);
            try
            {
                await handler.Invoke();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}
