namespace Rentaly.DtoLayer.CarModelDtos
{
    public class GetCarModelByIdDto
    {
        public int CarModelId { get; set; }
        public string ModelName { get; set; } = null!;
        public int BrandId { get; set; }
    }
}