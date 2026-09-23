namespace Rentaly.DtoLayer.CarDtos
{
    public class ResultCarDto
    {
        public int CarId { get; set; }
        public string PlateNumber { get; set; } = null!;
        public string BrandName { get; set; } = null!;
        public string ModelName { get; set; } = null!;
        public string CategoryName { get; set; } = null!;
        public string BranchName { get; set; } = null!;
        public int Year { get; set; }
        public decimal DailyPrice { get; set; }
        public bool IsActive { get; set; }
        public string ImageUrl { get; set; } = null!;
    }
}