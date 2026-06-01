namespace MedicalCenterApi;

public class StaffMember
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public Guid UserId { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public DateOnly DateOfBirth { get; set; }
    public int Sex { get; set; } = 0; // 0 - undefined, 1-male, 2-female
    public string Firstname { get; set; } = string.Empty;
    public string Lastname { get; set; } = string.Empty;
    public string Specialization { get; set; } = string.Empty;
    public string Position { get; set; } = string.Empty;
    public string ContactNumber { get; set; } = string.Empty;
}
