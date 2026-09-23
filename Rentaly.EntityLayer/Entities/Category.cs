namespace Rentaly.EntityLayer.Entities
{
    public class Category
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; } = null!;

        public ICollection<CarModel> CarModels { get; set; } = new List<CarModel>();
    }
}