using Macmillan.GraphQL.Account.Types;
using Microsoft.EntityFrameworkCore;

namespace Macmillan.GraphQL.Account.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public virtual DbSet<User> Users => Set<User>();

        public virtual DbSet<Address> Addresses => Set<Address>();

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<User>()
                .HasIndex(u => u.Email)
                .IsUnique();

            builder.Entity<User>()
                .HasMany(u => u.Addresses)
                .WithOne(a => a.User)
                .HasForeignKey(a => a.UserId);

            builder.Entity<User>()
                .HasOne(u => u.DefaultAddress)
                .WithOne()
                .HasForeignKey<User>(u => u.DefaultAddressId);
        }
    }
}
