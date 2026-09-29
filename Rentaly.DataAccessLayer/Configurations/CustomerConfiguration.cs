using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Rentaly.EntityLayer.Entities;

namespace Rentaly.DataAccessLayer.Configurations
{
    public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.Property(x => x.Name).IsRequired().HasMaxLength(50);
            builder.Property(x => x.Surname).IsRequired().HasMaxLength(50);
            builder.Property(x => x.Email).IsRequired().HasMaxLength(100);
            builder.Property(x => x.Phone).IsRequired().HasMaxLength(20);
            builder.Property(x => x.IdentityNumber).IsRequired().HasMaxLength(11);
            builder.Property(x => x.DrivingLicenseNumber).IsRequired().HasMaxLength(20);

            builder.HasIndex(x => x.IdentityNumber).IsUnique();
            builder.HasIndex(x => x.DrivingLicenseNumber).IsUnique();
        }
    }
}
