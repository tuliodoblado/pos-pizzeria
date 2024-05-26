namespace api_pospizzeria.Features.FOinv.Dtos
{
    public class OinvDto
    {
        public int Id { get; set; }

        public int IdOrder { get; set; }

        public int IdCustomer { get; set; }

        public int IdPaymentMethod { get; set; }

        public DateTime InvoiceDate { get; set; }

        public string Correlative { get; set; } = null!;

        public decimal TotalAmount { get; set; }

        public decimal? Taxes { get; set; }

        public decimal? Discounts { get; set; }

        public decimal NetAmount { get; set; }

        public string Status { get; set; } = null!;
    }
}
