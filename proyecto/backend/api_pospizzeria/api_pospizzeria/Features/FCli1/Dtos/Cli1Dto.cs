namespace api_pospizzeria.Features.FCli1.Dtos
{
    public class Cli1Dto
    {
        public int Id { get; set; }

        public int IdCustomer { get; set; }

        public string DeliveryAddress { get; set; } = null!;

        public string City { get; set; } = null!;

        public string? PostalCode { get; set; }

        public string State { get; set; } = null!;

        public string? ReferenceAddress { get; set; }

        public bool Status { get; set; }
    }
}
