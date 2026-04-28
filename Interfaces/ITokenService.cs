using System.Security.Claims;

namespace MedicalCenterApi;

public interface ITokenService
{
    public string GenerateRefreshToken();
    public string GenerateAccessToken(IEnumerable<Claim> claims);
    public ClaimsPrincipal GetUserClaimsFromAccessToken(string token);
}
