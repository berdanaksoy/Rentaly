using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Rentaly.EntityLayer.Entities;

namespace Rentaly.DataAccessLayer.Configurations
{
    public class CarModelConfiguration : IEntityTypeConfiguration<CarModel>
    {
        public void Configure(EntityTypeBuilder<CarModel> builder)
        {
            builder.Property(x => x.ModelName).IsRequired().HasMaxLength(60);

            builder.HasOne(x => x.Brand)
                .WithMany(x => x.CarModels)
                .HasForeignKey(x => x.BrandId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}