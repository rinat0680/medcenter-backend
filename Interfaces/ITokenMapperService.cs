using System.Diagnostics.Contracts;

namespace MedicalCenterApi.Interfaces;

public interface ITokenMapperService
{
    public string MapUserRole(bool isAdmin);
}