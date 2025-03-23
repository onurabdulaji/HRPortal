using HRPortal.Application.Interfaces.Services.AppRoleService;
using HRPortal.Domain.Interfaces.IUnitOfWorks;

namespace HRPortal.Application.Interfaces.Managers.AppRoleManager;

public class WriteAppRoleManager : IWriteAppRoleService
{
    private readonly IUnitOfWork _unitOfWork;

    public WriteAppRoleManager(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
}



