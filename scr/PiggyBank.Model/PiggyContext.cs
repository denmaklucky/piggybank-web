using Microsoft.EntityFrameworkCore;
using PiggyBank.Model.Models;

namespace PiggyBank.Model
{
    public class PiggyContext : DbContext
    {
        public PiggyContext(DbContextOptions<PiggyContext> options) : base(options) { }

        public DbSet<Account> Accounts { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Transaction> Transactions { get; set; }
    }
}
