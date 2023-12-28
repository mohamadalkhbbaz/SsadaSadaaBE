using JWT_Start.Dtos;

namespace JWT_Start.Services
{
    public interface IAuthService
    {
        Task<RegistrResultDto> RegisrUser(RegistrInputDto dto);
        Task<RegistrResultDto> GetToken(LoginInputDto dto);
    }
}
