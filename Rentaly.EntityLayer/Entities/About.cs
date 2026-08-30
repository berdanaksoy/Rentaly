namespace Rentaly.EntityLayer.Entities
{
    public class About
    {
        public int AboutId { get; set; }
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string ImageUrl { get; set; } = null!;
        public int CarCount { get; set; }
        public int CustomerCount { get; set; }
        public int BranchCount { get; set; }
        public int RentalCount { get; set; }
    }
}