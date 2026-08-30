namespace Rentaly.EntityLayer.Entities
{
    public class Brand
    {
        public int BrandId { get; set; }
        public string BrandName { get; set; } = null!;
        public string ImageUrl { get; set; } = null!;

        public ICollection<CarModel> CarModels { get; set; } = new List<CarModel>();
    }
}