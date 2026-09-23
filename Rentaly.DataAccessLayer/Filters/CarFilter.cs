namespace Rentaly.DataAccessLayer.Filters
{
    public class CarFilter
    {
        public int? BrandId { get; set; }
        public int? CategoryId { get; set; }
        public int? BranchId { get; set; }
        public decimal? MinPrice { get; set; }
        public decimal? MaxPrice { get; set; }
        public bool? IsActive { get; set; }
        public string? SearchTerm { get; set; }
    }
}