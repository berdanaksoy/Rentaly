namespace Rentaly.DtoLayer.BrandDtos
{
    public class GetBrandByIdDto
    {
        public int BrandId { get; set; }
        public string BrandName { get; set; } = null!;
        public string ImageUrl { get; set; } = null!;
    }
}