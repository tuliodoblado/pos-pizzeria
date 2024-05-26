namespace api_pospizzeria.Features.FOpmt.Dtos
{
    public class OpmtDto
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public string? Details { get; set; }

        public string ServiceProvider { get; set; } = null!;

        public bool Status { get; set; }
    }
}
