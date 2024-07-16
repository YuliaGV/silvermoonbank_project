using Microsoft.EntityFrameworkCore;
using Silvermoon.Core.Entities;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Silvermoon.Infrastructure.Data
{
    public class SilvermoonContext:DbContext
    {

        public SilvermoonContext(DbContextOptions<SilvermoonContext> options)
        : base(options)
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Card> Cards { get; set; }
        public DbSet<FinancialTransaction> FinancialTransactions { get; set; }
        public DbSet<TransferDetail> TransferDetails { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            var entitiesWithDecimalProperties = new (Type EntityType, string PropertyName)[]
            {
                (typeof(Account), "Balance"),
                (typeof(Card), "CreditLimit"),
                (typeof(Card), "AvailableBalance"),
                (typeof(FinancialTransaction), "Amount")
            };

            foreach (var entity in entitiesWithDecimalProperties)
            {
                modelBuilder.Entity(entity.EntityType)
                    .Property(entity.PropertyName)
                    .HasColumnType("decimal(15, 2)");
            }

        }




    }
}
