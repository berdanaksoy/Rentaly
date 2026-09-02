namespace Rentaly.DtoLayer.BrandDtos
{
    public class UpdateBrandDto
    {
        public int BrandId { get; set; }
        public string BrandName { get; set; } = null!;
        public string ImageUrl { get; set; } = null!;
    }
}