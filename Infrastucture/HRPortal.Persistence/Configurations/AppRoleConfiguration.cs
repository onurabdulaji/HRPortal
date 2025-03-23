using HRPortal.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HRPortal.Persistence.Configurations;

public class AppRoleConfiguration : BaseConfiguration<AppRole>
{
    public override void Configure(EntityTypeBuilder<AppRole> builder)
    {
        base.Configure(builder);

        builder.Property(x => x.Title)
            .IsRequired();

        builder.Property(x=>x.Roles)
            .IsRequired();

        builder.HasMany(x => x.Users)
            .WithOne(x => x.AppRole)
            .HasForeignKey(x => x.AppRoleId);
            
    }
}
