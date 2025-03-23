using HRPortal.Domain.Entities;
using HRPortal.DTO.Mapster.Base;

namespace HRPortal.DTO.DTO.Request.AppUserDtos;

public class CreateUserDTO : BaseDTO<CreateUserDTO, AppUser>
{
    public string? UserName { get; set; }
    public string? Email { get; set; }
    public string? Password { get; set; }
    public Guid? AppRoleId { get; set; }
}
