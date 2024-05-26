namespace api_pospizzeria.Features.FOodr.Dtos
{
    public class OodrDto
    {
        public int Id { get; set; }

        public int IdCustomer { get; set; }

        public int IdDeliveryAddress { get; set; }

        public int IdPaymentMethod { get; set; }

        public DateTime DateOrder { get; set; }

        public DateTime DateDelivery { get; set; }

        public string OrderStatus { get; set; } = null!;

        public string OrderNotes { get; set; } = null!;

        public decimal TotalPrice { get; set; }

        public decimal Taxes { get; set; }
    }
}
