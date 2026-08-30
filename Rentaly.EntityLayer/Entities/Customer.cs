namespace Rentaly.EntityLayer.Entities
{
    public class Customer
    {
        public int CustomerId { get; set; }
        public string Name { get; set; } = null!;
        public string Surname { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Phone { get; set; } = null!;
        public string IdentityNumber { get; set; } = null!;
        public string DrivingLicenseNumber { get; set; } = null!;
        public DateTime DrivingLicenseDate { get; set; }

        public ICollection<Rental> Rentals { get; set; } = new List<Rental>();
    }
}