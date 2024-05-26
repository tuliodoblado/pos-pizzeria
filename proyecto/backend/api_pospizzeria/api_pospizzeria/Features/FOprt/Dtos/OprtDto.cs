namespace api_pospizzeria.Features.FOprt.Dtos
{
    public class OprtDto
    {
        public int Id { get; set; }

        public int IdCategory { get; set; }

        public string Code { get; set; } = null!;

        public string? Description { get; set; }

        public decimal Price { get; set; }

        public string? Image { get; set; }

        public int AvailableStock { get; set; }

        public bool? Featured { get; set; }

        public bool Status { get; set; }
    }
}
