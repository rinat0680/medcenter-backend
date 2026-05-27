using MedicalCenterApi.DTOs;

namespace MedicalCenterApi.Interfaces;

public interface IAuthService
{
    public Task<RegisterResponseDto> RegisterAsync(RegisterRequestDto requestDto);
    public Task<LoginResponseDto> LoginAsync(LoginRequestDto requestDto);
    public Task<RefreshTokenResponseDto> RefreshAsync(RefreshTokenRequestDto requestDto);
    public Task<ResetResponseDto> ResetPasswordAsync(ResetRequestDto requestDto);
}
