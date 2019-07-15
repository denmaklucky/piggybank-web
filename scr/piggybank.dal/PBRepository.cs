using System;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using piggybank.dal.Configurates;
using piggybank.dal.Dto;
using piggybank.dal.Models;

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

        public async Task<bool> AddOrUpdateCategory(CategoryDto category)
        {
            bool result = false;
            if (category.Id == 0)
            {
                category.CreatedOn = DateTime.Now;
                await _context.Categories.AddAsync(Mapper.Map<Category>(category));

                result = true;
            }
            else
            {
                var categoryEntity = await _context.Categories.FirstOrDefaultAsync(c => c.Id == category.Id);
                if (categoryEntity != null)
                {
                    categoryEntity.Title = category.Title;
                    categoryEntity.HexColor = category.HexColor;
                    categoryEntity.Type = category.Type;
                    categoryEntity.IsDeleted = category.IsDeleted;
                    categoryEntity.IsRequired = category.IsRequired;
                    categoryEntity.ModifiedOn = DateTime.Now;

                    result = true;
                }
            }

            await _context.SaveChangesAsync();
            return result;
        }

        public async Task<bool> AddOrUpdateAccount(AccountDto account)
        {
            bool result = false;
            if (account.Id == 0)
            {
                account.CreatedOn = DateTime.Now;
                await _context.Accounts.AddAsync(Mapper.Map<Account>(account));

                result = true;
            }
            else
            {
                var accountEntity = await _context.Accounts.FirstOrDefaultAsync(c => c.Id == account.Id);
                if (accountEntity != null)
                {
                    accountEntity.Title = account.Title;
                    accountEntity.Type = account.Type;
                    accountEntity.IsDeleted = account.IsDeleted;
                    accountEntity.IsArchived = account.IsArchived;
                    accountEntity.Balance = account.Balance;
                    accountEntity.Currency = account.Currency;
                    accountEntity.ModifiedOn = DateTime.Now;

                    result = true;
                }
            }

            await _context.SaveChangesAsync();
            return result;
        }

        public IQueryable<TransactionDto> Transactions => _context.Transactions.ProjectTo<TransactionDto>();
        public IQueryable<AccountDto> Accounts => _context.Accounts.ProjectTo<AccountDto>();
        public IQueryable<CategoryDto> Categories => _context.Categories.ProjectTo<CategoryDto>();
    }
}
