namespace MedicalCenterApi;

public class LoginRequestDto
{
    public string Email { get; set; } = null!;
    public string UserName { get; set; } = null!;
    public string Password { get; set; } = null!;
}
