using HRPortal.DTO.DTO.Request.AppUserDtos;
using MediatR;

namespace HRPortal.Application.Features.UserSlice.Commands.CreateUser;

public class CreateUserRequest : IRequest<CreateUserDTO>
{
    public CreateUserDTO CreateUserDTO { get; set; }
}
