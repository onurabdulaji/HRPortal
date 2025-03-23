﻿using HRPortal.Domain.Entities;
using HRPortal.Domain.Interfaces.IUnitOfWorks;

namespace HRPortal.Persistence.Context.Seed;

public class AdminSeed
{
    private readonly IUnitOfWork _unitOfWork;

    public AdminSeed(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task SeedAsync()
    {
        // Admin rolünü oluştur veya kontrol et.
        var adminRole = await _unitOfWork.TGetReadAppRoleRepository.GetEntityAsync(r => r.Roles.GetType);
        if (adminRole == null)
        {
            adminRole = new AppRole { Title = "Admin"};
            _unitOfWork.TGetWriteAppRoleRepository.CreateRole(adminRole);
            await _unitOfWork.SaveAsync();
        }
    }
}
