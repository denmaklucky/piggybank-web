using Microsoft.EntityFrameworkCore;
using piggybank.dal.Models;

namespace piggybank.dal
{
    public class PiggyBankContext : DbContext
    {
        protected PiggyBankContext()
        {
        }

        public DbSet<Transaction> Transactions { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Account> Accounts { get; set; }

    }
}
