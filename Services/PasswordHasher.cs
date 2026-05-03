using MedicalCenterApi.Interfaces;

namespace MedicalCenterApi.Services;

public class PasswordHasher : IPasswordHasher
{
    public string Hash(string password)
    {
        throw new NotImplementedException();
    }

    public bool Verify(string password, string hash)
    {
        throw new NotImplementedException();
    }
}
