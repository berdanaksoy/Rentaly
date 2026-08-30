using Rentaly.EntityLayer.Enums;

namespace Rentaly.EntityLayer.Entities
{
    public class Car
    {
        public int CarId { get; set; }
        public string PlateNumber { get; set; } = null!;
        public string VIN { get; set; } = null!;

        public int CarModelId { get; set; }
        public CarModel CarModel { get; set; } = null!;

        public int CategoryId { get; set; }
        public Category Category { get; set; } = null!;

        public int BranchId { get; set; }
        public Branch Branch { get; set; } = null!;

        public int Year { get; set; }
        public int Kilometer { get; set; }
        public decimal DailyPrice { get; set; }
        public decimal DepositAmount { get; set; }
        public bool IsActive { get; set; }
        public string ImageUrl { get; set; } = null!;
        public int SeatCount { get; set; }
        public int LuggageCount { get; set; }
        public FuelType FuelType { get; set; }
        public TransmissionType Transmission { get; set; }

        public ICollection<Rental> Rentals { get; set; } = new List<Rental>();
    }
}