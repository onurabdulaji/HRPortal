using HRPortal.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HRPortal.Persistence.Configurations;

public class EmployeeConfiguration : BaseConfiguration<Employee>
{
    public override void Configure(EntityTypeBuilder<Employee> builder)
    {
        base.Configure(builder);

        builder.Property(x => x.FirstName)
            .IsRequired();

        builder.Property(x => x.LastName)
            .IsRequired();

        builder.Property(x => x.NationalIdentityNumber)
            .IsRequired();

        builder.Property(x => x.DateOfBirth)
            .IsRequired();

        builder.Property(x => x.Gender)
            .IsRequired();

        builder.Property(x => x.Email)
            .IsRequired();

        builder.Property(x => x.PhoneNumber)
            .IsRequired();

        builder.Property(x => x.Address)
            .IsRequired();

        builder.Property(x => x.Photo)
            .IsRequired();

        builder.Property(x => x.HireDate)
            .IsRequired();

        builder.Property(x => x.TerminationDate)
            .IsRequired();

        // Employee ve AppUser arasındaki bire bir ilişki yapılandırması
        builder.HasOne(x => x.AppUser)
            .WithOne(x => x.Employee)
            .HasForeignKey<Employee>(x => x.AppUserId);
    }
}
