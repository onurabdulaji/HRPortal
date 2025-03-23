using HRPortal.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HRPortal.Persistence.Configurations;

public class AppUserConfiguration : BaseConfiguration<AppUser>
{
    public override void Configure(EntityTypeBuilder<AppUser> builder)
    {
        base.Configure(builder);

        builder.Property(x => x.UserName)
            .IsRequired();

        builder.Property(x => x.Email)
            .IsRequired();

        builder.Property(x => x.PasswordHash)
            .IsRequired();

        // AppUser ve AppRole arasındaki bire çok ilişki yapılandırması
        builder.HasOne(x => x.AppRole)
            .WithMany(x => x.Users)
            .HasForeignKey(x => x.AppRoleId);

        // AppUser ve Employee arasındaki bire bir ilişki yapılandırması
        builder.HasOne(x => x.Employee)
            .WithOne(x=>x.AppUser)
            .HasForeignKey<AppUser>(x=>x.EmployeeId);
    }
}
