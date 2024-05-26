namespace api_pospizzeria.Features.FOusr.Dtos
{
    public class OusrDto
    {
        public int Id { get; set; }

        public int IdRol { get; set; }

        public string NameUser { get; set; } = null!;

        public string Name { get; set; } = null!;

        public string? LastName { get; set; }

        public string Email { get; set; } = null!;

        public string Password { get; set; } = null!;

        public string? Comments { get; set; }

        public bool Status { get; set; }
    }
}
