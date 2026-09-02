namespace Rentaly.DtoLayer.BranchDtos
{
    public class ResultBranchDto
    {
        public int BranchId { get; set; }
        public string BranchName { get; set; } = null!;
        public string City { get; set; } = null!;
        public string Address { get; set; } = null!;
    }
}
