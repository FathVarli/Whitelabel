using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Whitelabel.Domain.Entities.Concrete;

namespace Whitelabel.Infrastructure.Context.Configuration;

public class TenantTypeConfiguration : IEntityTypeConfiguration<Tenant>
{
    public void Configure(EntityTypeBuilder<Tenant> builder)
    {
        builder.HasData(new Tenant
        {
            Id = 1,
            Name = "Test Tenant",
        });
    }
}