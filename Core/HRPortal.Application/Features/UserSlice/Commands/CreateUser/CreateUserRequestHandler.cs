using HRPortal.Application.Interfaces.Services.AppUserService;
using HRPortal.DTO.DTO.Request.AppUserDtos;
using MediatR;

namespace HRPortal.Application.Features.UserSlice.Commands.CreateUser;

public class CreateUserRequestHandler : IRequestHandler<CreateUserRequest, CreateUserDTO>
{
    private readonly IWriteAppUserService _appUserService;

    public CreateUserRequestHandler(IWriteAppUserService appUserService)
    {
        _appUserService = appUserService;
    }

    public async Task<CreateUserDTO> Handle(CreateUserRequest request, CancellationToken cancellationToken)
    {
        return null;
    }
}
