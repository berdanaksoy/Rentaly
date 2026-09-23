namespace Rentaly.DtoLayer.CarModelDtos
{
    public class ResultCarModelDto
    {
        public int CarModelId { get; set; }
        public string ModelName { get; set; } = null!;
        public int BrandId { get; set; }
        public string BrandName { get; set; } = null!;
        public int CategoryId { get; set; }
        public string CategoryName { get; set; } = null!;
    }
}