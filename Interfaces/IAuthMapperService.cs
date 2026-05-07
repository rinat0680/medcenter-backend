using MedicalCenterApi.Entities;
using System.Diagnostics.Contracts;

namespace MedicalCenterApi.Interfaces;

public interface IAuthMapperService
{
    public string MapUserRole(bool isAdmin);
}