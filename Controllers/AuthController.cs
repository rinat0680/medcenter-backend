using Microsoft.AspNetCore.Mvc;

namespace MedicalCenterApi;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly ITokenService _tokenService;
    public AuthController(ITokenService tokenService)
    {  
        _tokenService = tokenService; 
    }
    [HttpPost("register")]
    public IActionResult Register([FromBody] RegisterRequestDto requestDto)
    {
        return Ok(requestDto);
    }
    [HttpPost("login")]
    public IActionResult Login([FromBody] LoginRequestDto requestDto)
    {
        return Ok(requestDto);
    }
    [HttpPost("refresh")]
    public IActionResult Refresh()
    {
        return Ok("Token refreshed");
    } 
}
