using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace piggybank.dal
{
    public class PiggyContextFactory : IDesignTimeDbContextFactory<PiggyContext>
    {
        public PiggyContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<PiggyContext>();
            builder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=Piggy;Trusted_Connection=True;MultipleActiveResultSets=true");
            return new PiggyContext(builder.Options);
        }
    }
}
