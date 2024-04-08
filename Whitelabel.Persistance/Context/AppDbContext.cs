using Microsoft.EntityFrameworkCore;
using Whitelabel.Domain.Entities.Concrete;
using Whitelabel.Infrastructure.Context.Configuration;

namespace Whitelabel.Infrastructure.Context
{
    public class AppDbContext : DbContext
    {
     
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new TenantTypeConfiguration());
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Tenant> Tenants { get; set; }
        public DbSet<Domain.Entities.Concrete.Whitelabel> Whitelabels { get; set; }
        
    }
}