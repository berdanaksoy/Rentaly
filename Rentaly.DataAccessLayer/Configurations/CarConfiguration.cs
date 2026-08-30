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

            builder.HasIndex(x => x.PlateNumber).IsUnique();
        }
    }
}