namespace Rentaly.DtoLayer.CustomerDtos
{
    public class ResultCustomerDto
    {
        public int CustomerId { get; set; }
        public string Name { get; set; } = null!;
        public string Surname { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Phone { get; set; } = null!;
    }
}
