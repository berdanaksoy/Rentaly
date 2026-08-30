namespace Rentaly.EntityLayer.Entities
{
    public class Award
    {
        public int AwardId { get; set; }
        public string Title { get; set; } = null!;
        public string ImageUrl { get; set; } = null!;
        public int Year { get; set; }
    }
}