using Microsoft.EntityFrameworkCore;
using piggybank.dal.Models;

namespace piggybank.dal
{
    public class PiggyContext : DbContext
    {
        public PiggyContext(DbContextOptions<PiggyContext> options) 
            : base(options)
        {
        }

        public DbSet<Transaction> Transactions { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Account> Accounts { get; set; }
    }
}
