using HRPortal.Domain.Entities;
using HRPortal.Domain.Enums;
using HRPortal.DTO.Mapster.Base;

namespace HRPortal.DTO.DTO.Request.AppRoleDtos;

public class CreateRoleDto : BaseDTO<CreateRoleDto, AppRole>
{
    public Roles Roles { get; set; }
}


public class AssignRole : BaseDTO<AssignRole, AppRole>
{
    public Roles Roles { get; set; }
}
