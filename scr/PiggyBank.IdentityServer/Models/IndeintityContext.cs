using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace PiggyBank.IdentityServer.Models
{
    public class IndeintityContext : IdentityDbContext
    {
        public IndeintityContext(DbContextOptions options)
            : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<IdentityUser>().ToTable("Users");
            builder.Entity<IdentityRole>().ToTable("Roles");
            builder.Entity<IdentityRole>().ToTable("role");
            builder.Entity<IdentityUserRole<string>>().ToTable("UserRoles");
            builder.Entity<IdentityUserClaim<string>>().ToTable("UserClaims");
            builder.Entity<IdentityUserLogin<string>>().ToTable("UserLogins");
        }
    }

    public class IndeintityContextFactory : IDesignTimeDbContextFactory<IndeintityContext>
    {
        public IndeintityContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<IndeintityContext>();
            builder.UseSqlServer("Server=(local)\\SQL2016;Database=PiggyBank;Trusted_Connection=True;MultipleActiveResultSets=true");
            return new IndeintityContext(builder.Options);
        }
    }
}
