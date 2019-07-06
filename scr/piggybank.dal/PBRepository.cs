using System;
using System.Linq;
using AutoMapper.QueryableExtensions;
using piggybank.dal.Configurates;
using piggybank.dal.DTO;

namespace piggybank.dal.Contracts
{
    public class PBRepository : IPBRepository
    {
        public PiggyContext _context;
        public PBRepository(PiggyContext context)
        {
            _context = context;
            MapperConfigurate.Configurate();
        }

        public IQueryable<TransactionDto> Transactions => _context.Transactions.ProjectTo<TransactionDto>();

        public IQueryable<AccountDto> Accounts => _context.Accounts.ProjectTo<AccountDto>();
        public IQueryable<CategoryDto> Categories => _context.Categories.ProjectTo<CategoryDto>();
    }
}
