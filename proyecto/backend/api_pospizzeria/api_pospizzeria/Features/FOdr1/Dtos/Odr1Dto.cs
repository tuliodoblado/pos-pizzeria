namespace api_pospizzeria.Features.FOdr1.Dtos
{
    public class Odr1Dto
    {
        public int Id { get; set; }

        public int IdOrder { get; set; }

        public int IdProducts { get; set; }

        public int Quantity { get; set; }

        public decimal UnitPrice { get; set; }

        public decimal Subtotal { get; set; }
    }
}
