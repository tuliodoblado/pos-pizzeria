using api_pospizzeria.Features.FAccess.Dtos;

namespace api_pospizzeria.Features.FAccess
{
    public interface IAccessService
    {
        Task<string> AuthenticateAsync(AccessDto loginRequest);
    }
}
