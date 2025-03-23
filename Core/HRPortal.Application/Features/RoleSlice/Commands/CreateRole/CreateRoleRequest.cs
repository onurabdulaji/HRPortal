using HRPortal.DTO.DTO.Request.AppRoleDtos;
using MediatR;

namespace HRPortal.Application.Features.RoleSlice.Commands.CreateRole;

public class CreateRoleRequest : IRequest<CreateRoleDto>
{
    public CreateRoleDto CreateRoleDto { get; set; }
}
