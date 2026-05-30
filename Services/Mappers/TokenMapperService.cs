using MedicalCenterApi.Interfaces;

namespace MedicalCenterApi.Services.Mappers;

public class TokenMapperService : ITokenMapperService
{
    public string MapUserRole(bool isAdmin)
    {
        return isAdmin ? "Admin" : "User";
    }
}