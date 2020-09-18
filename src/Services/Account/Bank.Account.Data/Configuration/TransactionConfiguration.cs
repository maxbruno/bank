using Bank.Account.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Bank.Account.Data.Configuration
{
    public class TransactionConfiguration : IEntityTypeConfiguration<Transaction>
    {
        public void Configure(EntityTypeBuilder<Transaction> builder)
        {
            builder.ToTable("Transaction", "dbo").HasKey(t => t.Id);
            
            builder.Property(t => t.TransactionType)
                .IsRequired()
                .HasColumnType("int");
            
            builder.Property(t => t.Value)
                .IsRequired()
                .HasColumnType("decimal(18,3)");
            
            builder.Property(t => t.CreateAt)
                .IsRequired()
                .HasColumnType("datetime2");
        }
    }
}