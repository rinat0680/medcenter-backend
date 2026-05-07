using MedicalCenterApi.Entities;
using System.Security.Claims;

namespace MedicalCenterApi;

public interface ITokenService
{
    public string GenerateRefreshToken();
    public string GenerateAccessToken(IEnumerable<Claim> claims);
    public IEnumerable<Claim> GetClaimsForUser(User user);
    public ClaimsPrincipal? GetUserClaimsFromAccessToken(string token);
}
