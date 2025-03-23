using HRPortal.Application.Interfaces.Services.AppRoleService;
using HRPortal.DTO.DTO.Request.AppRoleDtos;
using MediatR;

namespace HRPortal.Application.Features.RoleSlice.Commands.CreateRole;

public class CreateRoleRequestHandler : IRequestHandler<CreateRoleRequest, CreateRoleDto>
{
    private readonly IWriteAppRoleService _roleService;

    public CreateRoleRequestHandler(IWriteAppRoleService roleService)
    {
        _roleService = roleService;
    }

    public async Task<CreateRoleDto> Handle(CreateRoleRequest request, CancellationToken cancellationToken)
    {
       return null;
    }
}
