using MedicalCenterApi.Entities;
using MedicalCenterApi.Interfaces;

namespace MedicalCenterApi.Services.Mappers;

public class AuthMapperService : IAuthMapperService
{
    public string MapUserRole(bool isAdmin)
    {
        return isAdmin ? "Admin" : "User";
    }
}