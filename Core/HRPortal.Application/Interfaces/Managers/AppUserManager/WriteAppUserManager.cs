using HRPortal.Application.Interfaces.Services.AppUserService;
using HRPortal.Domain.Interfaces.IUnitOfWorks;

namespace HRPortal.Application.Interfaces.Managers.AppUserManager;

public class WriteAppUserManager : IWriteAppUserService
{
    private readonly IUnitOfWork _unitOfWork;

    public WriteAppUserManager(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
}

    