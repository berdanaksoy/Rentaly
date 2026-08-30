namespace Rentaly.EntityLayer.Entities
{
    public class CarModel
    {
        public int CarModelId { get; set; }
        public string ModelName { get; set; } = null!;

        public int BrandId { get; set; }
        public Brand Brand { get; set; } = null!;

        public ICollection<Car> Cars { get; set; } = new List<Car>();
    }
}