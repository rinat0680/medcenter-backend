using MedicalCenterApi.DTOs;
using MedicalCenterApi.Entities;
using MedicalCenterApi.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace MedicalCenterApi;

public class AuthService : IAuthService
{
    private readonly IPasswordHasher _hasher;
    private readonly ITokenService _tokenService;
    private readonly AppDbContext _appDbContext;
    public AuthService(IPasswordHasher hasher, ITokenService tokenService, AppDbContext appDbContext)
    {
        _hasher = hasher;
        _tokenService = tokenService;
        _appDbContext = appDbContext;
    }
    public async Task<RegisterResponseDto> RegisterAsync(RegisterRequestDto requestDto)
    {
        if (await _appDbContext.Users.AnyAsync(u => u.Email == requestDto.Email))
        {
            return new RegisterResponseDto { Code = 1, Message = "email already exists" };
        }

        var user = new User
        {
            Email = requestDto.Email,
            Password = _hasher.Hash(requestDto.Password)
        };

        _appDbContext.Users.Add(user);
        await _appDbContext.SaveChangesAsync();

        return new RegisterResponseDto { Code = 0, Id = user.Id ,Email = user.Email };
    }
    
    public async Task<LoginResponseDto> LoginAsync(LoginRequestDto requestDto)
    {
        var response = new LoginResponseDto();
        var user = await _appDbContext.Users.FirstOrDefaultAsync(u => (u.Email == requestDto.Email)||(u.Username == requestDto.Username));
        if (user == null)
            return new LoginResponseDto { Code = 1, Message = "user not found" };

        if (!_hasher.Verify(requestDto.Password, user.Password))
            return new LoginResponseDto { Code = 1, Message = "wrong password or email/username" };

        IEnumerable<Claim> claims = _tokenService.GetClaimsForUser(user);
        response.AccessToken = _tokenService.GenerateAccessToken(claims);
        response.RefreshToken = _tokenService.GenerateRefreshToken();
        var token = await _appDbContext.RefreshTokens.FirstOrDefaultAsync(t => t.UserId == user.Id);
        if (token == null)
        {
            
            var refreshToken = new RefreshToken
            {
                UserId = user.Id,
                Token = response.RefreshToken,
                ExpiresAt = DateTime.UtcNow.AddDays(7)
            };
            await _appDbContext.RefreshTokens.AddAsync(refreshToken);
            await _appDbContext.SaveChangesAsync();
            return response;
        }
        token.Token = response.RefreshToken;
        token.ExpiresAt = DateTime.UtcNow.AddDays(7);
        await _appDbContext.SaveChangesAsync();
        return response;
        ;
    }
    public async Task<RefreshTokenResponseDto> RefreshAsync(RefreshTokenRequestDto requestDto)
    {
        RefreshTokenResponseDto response = new RefreshTokenResponseDto();
        var principal = _tokenService.GetUserClaimsFromAccessToken(requestDto.AccessToken);
        if (principal == null)
        {
            response.Code = 1;
            response.Message = "Invalid access token";
            return response;
        }
        var userId = principal.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
        if(userId != null)
        {
            var token = await _appDbContext.RefreshTokens.FirstOrDefaultAsync(t => t.UserId.ToString() == userId);
            if (token == null || token.Token != requestDto.RefreshToken || token.ExpiresAt < DateTime.UtcNow)
            {
                response.Code = 1;
                response.Message = "Invalid refresh token";
                return response;
            }
            var user = await _appDbContext.Users.FirstOrDefaultAsync(u => u.Id.ToString() == userId);
            if (user == null)
            {
                response.Code = 1;
                response.Message = "User not found";
                return response;
            }
            IEnumerable<Claim> claims = _tokenService.GetClaimsForUser(user);
            response.AccessToken = _tokenService.GenerateAccessToken(claims);
        }
        return response;
    }

 
}
