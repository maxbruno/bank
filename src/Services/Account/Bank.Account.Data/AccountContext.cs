using System.Reflection;
using Microsoft.EntityFrameworkCore;

namespace Bank.Account.Data
{
    public class AccountContext : DbContext
    {
        public AccountContext(DbContextOptions<AccountContext> options)
            : base(options)
        {
        
        }

        public DbSet<Domain.Models.Account> Account { get; set; }
        public DbSet<Domain.Models.Transaction> Transaction { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetAssembly(typeof(AccountContext)));
            base.OnModelCreating(modelBuilder);
        }
    }
}