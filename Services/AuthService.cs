using MedicalCenterApi.Interfaces;

namespace MedicalCenterApi;

public class AuthService : IAuthService
{
    private readonly IPasswordHasher _hasher;
    private readonly ITokenService _tokenService;
    public AuthService(IPasswordHasher hasher, ITokenService tokenService)
    {
        _hasher = hasher;
        _tokenService = tokenService;
    }
}
