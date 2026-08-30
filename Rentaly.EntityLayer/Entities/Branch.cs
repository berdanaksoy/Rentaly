namespace Rentaly.EntityLayer.Entities
{
    public class Branch
    {
        public int BranchId { get; set; }
        public string BranchName { get; set; } = null!;
        public string City { get; set; } = null!;
        public string Address { get; set; } = null!;

        public ICollection<Car> Cars { get; set; } = new List<Car>();
        public ICollection<Rental> PickupRentals { get; set; } = new List<Rental>();
        public ICollection<Rental> ReturnRentals { get; set; } = new List<Rental>();
    }
}