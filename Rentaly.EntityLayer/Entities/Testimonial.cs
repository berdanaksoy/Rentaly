namespace Rentaly.EntityLayer.Entities
{
    public class Testimonial
    {
        public int TestimonialId { get; set; }
        public string FullName { get; set; } = null!;
        public string Title { get; set; } = null!;
        public string Comment { get; set; } = null!;
        public string ImageUrl { get; set; } = null!;
    }
}