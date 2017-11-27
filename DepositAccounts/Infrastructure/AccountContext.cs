using DepositAccounts.Models;
using Microsoft.EntityFrameworkCore;


namespace DepositAccounts.Infrastructure
{
    public class AccountContext : DbContext
    {
        public AccountContext(DbContextOptions<AccountContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Account>();

            modelBuilder.Entity<Profile>();
        }

        public DbSet<Account> Accounts { get; set; }

        public DbSet<Profile> Profiles { get; set; }
    }
}
