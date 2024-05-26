namespace api_pospizzeria.Features.FOcli.Dtos
{
    public class OcliDto
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public string? Mobile { get; set; }

        public string? Email { get; set; }

        public byte[] NationalIdentification { get; set; } = null!;

        public bool Status { get; set; }
    }
}
