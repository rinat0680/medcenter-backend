namespace MedicalCenterApi;

public class RefreshToken
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Token { get; set; } = string.Empty;
    public Guid UserId { get; set; } = new Guid();
    public DateTime ExpiresAt { get; set; }

}
