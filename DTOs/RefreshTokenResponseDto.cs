namespace MedicalCenterApi;

public class RefreshTokenResponseDto
{
    public int Code { get; set; } = 0;
    public string Message { get; set; } = string.Empty;
    public string AccessToken { get; set; } = string.Empty;
}
