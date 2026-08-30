namespace Rentaly.EntityLayer.Entities
{
    public class Process
    {
        public int ProcessId { get; set; }
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string IconClass { get; set; } = null!;
        public int DisplayOrder { get; set; }
    }
}