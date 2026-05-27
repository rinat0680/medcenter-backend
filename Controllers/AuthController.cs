using MedicalCenterApi.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace MedicalCenterApi;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly IAuthService _authService;
    public AuthController(IAuthService authService)
    {
        _authService = authService;
    }
    [HttpPost("register")]
    public async Task<IActionResult> RegisterAsync([FromBody] RegisterRequestDto requestDto)
    {
        var response = await _authService.RegisterAsync(requestDto);
        return Ok(response);
    }
    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginRequestDto requestDto)
    {
        var response = await _authService.LoginAsync(requestDto);
        return Ok(response);
    }
    [HttpPost("refresh")]
    public async Task<IActionResult> Refresh([FromBody] RefreshTokenRequestDto requestDto)
    {
        var response = await _authService.RefreshAsync(requestDto);
        return Ok(response);
    }
    [HttpPost("reset-password")]
    public async Task<IActionResult> ResetPassword([FromBody] ResetRequestDto requestDto)
    {
        var response = await _authService.ResetPasswordAsync(requestDto);
        return Ok(requestDto);
    }
}
