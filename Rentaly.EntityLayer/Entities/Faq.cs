namespace Rentaly.EntityLayer.Entities
{
    public class Faq
    {
        public int FaqId { get; set; }
        public string Question { get; set; } = null!;
        public string Answer { get; set; } = null!;
    }
}