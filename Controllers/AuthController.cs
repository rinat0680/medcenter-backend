using MedicalCenterApi.Interfaces;
using Microsoft.AspNetCore.Authorization;
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
        switch (response.Code)
        {
            case 0:
                return Ok(response);
            case 1:
                return BadRequest(response);
            default:
                return StatusCode(500, response);
        }
    }
    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginRequestDto requestDto)
    {
        var response = await _authService.LoginAsync(requestDto);
        switch (response.Code)
        {
            case 0: return Ok(response);
            case 1: return BadRequest(response);
            default: return StatusCode(500, response);
        }
    }
    [HttpPost("refresh")]
    public async Task<IActionResult> Refresh([FromBody] RefreshTokenRequestDto requestDto)
    {
        var response = await _authService.RefreshAsync(requestDto);
        return Ok(response);
    }
}
