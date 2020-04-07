using Microsoft.EntityFrameworkCore;
using Persistence_Layer.Models;

namespace Persistence_Layer.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            
        }

        // public DbSet<Value> Values { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Business> Businesses { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<AccountType> AccountTypes { get; set; }
        public DbSet<Relationship> Relationships { get; set; }
        public DbSet<TransactionType> TransactionTypes { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Account> Account { get; set; }

protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<UserRole>()
            .HasKey(t => new { t.UserId, t.RoleId });

        modelBuilder.Entity<UserRole>()
            .HasOne(pt => pt.User)
            .WithMany(p => p.UserRole)
            .HasForeignKey(pt => pt.UserId);

        modelBuilder.Entity<UserRole>()
            .HasOne(pt => pt.Role)
            .WithMany(t => t.UserRole)
            .HasForeignKey(pt => pt.RoleId);
    }

        // protected override void OnModelCreating(ModelBuilder builder)
        // {
        //     builder.Entity<Value>().HasData(
        //         new Value { Id = 1, Name = "Value 101" },
        //         new Value { Id = 2, Name = "Value 102" },
        //         new Value { Id = 3, Name = "Value 103" }
        //     );
        // }
    }
}