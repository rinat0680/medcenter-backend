namespace MedicalCenterApi.DTOs
{
    public class LoginResponseDto
    {
        public int Code { get; set; } = 0;
        public string Message { get; set; } = string.Empty;
        public string AccessToken { get; set; }= string.Empty;
        public string RefreshToken { get; set; } = string.Empty;
    }
}
