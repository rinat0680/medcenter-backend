namespace MedicalCenterApi.DTOs;

public class RegisterResponseDto
{
    public int Code { get; set; } = 0; // 0 - success, 1 - error
    public string Message { get; set; } = string.Empty;
    public Guid? Id { get; set; }
    public string Email { get; set; } = string.Empty;
}
