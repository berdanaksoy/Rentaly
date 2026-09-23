namespace Rentaly.DtoLayer.CarModelDtos
{
    public class CreateCarModelDto
    {
        public string ModelName { get; set; } = null!;
        public int BrandId { get; set; }
        public int CategoryId { get; set; }
    }
}