using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Rentaly.EntityLayer.Entities;

namespace Rentaly.DataAccessLayer.Configurations
{
    public class RentalConfiguration : IEntityTypeConfiguration<Rental>
    {
        public void Configure(EntityTypeBuilder<Rental> builder)
        {
            builder.Property(x => x.TotalPrice).HasPrecision(18, 2);

            builder.HasOne(x => x.PickupBranch)
                .WithMany(x => x.PickupRentals)
                .HasForeignKey(x => x.PickupBranchId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.ReturnBranch)
                .WithMany(x => x.ReturnRentals)
                .HasForeignKey(x => x.ReturnBranchId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.Car)
                .WithMany(x => x.Rentals)
                .HasForeignKey(x => x.CarId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.Customer)
                .WithMany(x => x.Rentals)
                .HasForeignKey(x => x.CustomerId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}