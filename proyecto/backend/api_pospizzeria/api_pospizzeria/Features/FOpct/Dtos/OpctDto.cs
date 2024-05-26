namespace api_pospizzeria.Features.FOpct.Dtos
{
    public class OpctDto
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public string Description { get; set; } = null!;

        public bool Status { get; set; }
    }
}
