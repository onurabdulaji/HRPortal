using HRPortal.Application.Features.RoleSlice.Commands.CreateRole;
using HRPortal.Application.Features.UserSlice.Commands.CreateUser;
using HRPortal.DTO.DTO.Request.AppRoleDtos;
using HRPortal.DTO.DTO.Request.AppUserDtos;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace HRPortal.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestingsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TestingsController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost("CreateRole")]
        public async Task<IActionResult> CreateRole([FromBody] CreateRoleDto createRoleDto)
        {
            var request = new CreateRoleRequest { CreateRoleDto = createRoleDto };
            var result = await _mediator.Send(request);
            return Ok(result);
        }
    }
}
