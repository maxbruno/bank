using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Bank.Account.Data.Configuration
{
    public class AccountConfiguration : IEntityTypeConfiguration<Domain.Models.Account>
    {
        public void Configure(EntityTypeBuilder<Domain.Models.Account> builder)
        {
            // builder.ToTable("Account", "dbo").HasKey(t => t.Id);
            
            // builder.Property(t => t.AccountNumber)
            //     .IsRequired()
            //     .HasColumnType("varchar(20)");
            
            // builder.Property(t => t.AgencyNumber)
            //     .IsRequired()
            //     .HasColumnType("varchar(20)");
            
            // builder.Property(t => t.AccountHolder)
            //     .IsRequired()
            //     .HasColumnType("varchar(256)");
            
            // builder.Property(t => t.AccountBalance)
            //     .IsRequired()
            //     .HasColumnType("decimal(18,3)");
            
            // builder.HasMany(t => t.Transactions);
        }
    }
}
