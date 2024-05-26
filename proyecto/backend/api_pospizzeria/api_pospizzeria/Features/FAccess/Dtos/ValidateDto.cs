namespace api_pospizzeria.Features.FAccess.Dtos
{
    public class ValidateDto
    {
        public string Token { get; set; } = null!;
        public bool active { get; set; }
    }
}
