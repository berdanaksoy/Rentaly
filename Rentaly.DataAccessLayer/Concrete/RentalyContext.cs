using Microsoft.EntityFrameworkCore;
using Rentaly.EntityLayer.Entities;

namespace Rentaly.DataAccessLayer.Concrete
{
    public class RentalyContext : DbContext
    {
        public RentalyContext(DbContextOptions<RentalyContext> options) : base(options)
        {
        }

        public DbSet<Branch> Branches { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Car> Cars { get; set; }
        public DbSet<CarModel> CarModels { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Rental> Rentals { get; set; }

        public DbSet<Process> Processes { get; set; }
        public DbSet<OurFuture> OurFutures { get; set; }
        public DbSet<About> Abouts { get; set; }
        public DbSet<Award> Awards { get; set; }
        public DbSet<Testimonial> Testimonials { get; set; }
        public DbSet<Faq> Faqs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(RentalyContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}