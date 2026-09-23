using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Rentaly.EntityLayer.Entities;

namespace Rentaly.DataAccessLayer.Configurations
{
    public class CarConfiguration : IEntityTypeConfiguration<Car>
    {
        public void Configure(EntityTypeBuilder<Car> builder)
        {
            builder.Property(x => x.DailyPrice).HasPrecision(18, 2);
            builder.Property(x => x.DepositAmount).HasPrecision(18, 2);

            builder.Property(x => x.PlateNumber).IsRequired().HasMaxLength(10);
            builder.Property(x => x.VIN).IsRequired().HasMaxLength(17);
            builder.Property(x => x.ImageUrl).IsRequired().HasMaxLength(300);

            builder.HasIndex(x => x.PlateNumber).IsUnique();

            builder.HasIndex(x => x.VIN).IsUnique();

            builder.HasOne(x => x.CarModel)
                .WithMany(x => x.Cars)
                .HasForeignKey(x => x.CarModelId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.Branch)
                .WithMany(x => x.Cars)
                .HasForeignKey(x => x.BranchId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}