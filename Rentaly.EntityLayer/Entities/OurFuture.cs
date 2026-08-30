namespace Rentaly.EntityLayer.Entities
{
    public class OurFuture
    {
        public int OurFutureId { get; set; }
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string ImageUrl { get; set; } = null!;
    }
}