using Rentaly.EntityLayer.Enums;

namespace Rentaly.DtoLayer.CarDtos
{
    public class GetCarByIdDto
    {
        public int CarId { get; set; }
        public string PlateNumber { get; set; } = null!;
        public string VIN { get; set; } = null!;
        public int CarModelId { get; set; }
        public int BranchId { get; set; }
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
    }
}