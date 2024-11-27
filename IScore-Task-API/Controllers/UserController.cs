using Application.Components.Books.List;
using Application.Components.Users.AssignUserRoles;
using Application.Components.Users.GetUserData;
using Application.Constants;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IScore_Task_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UserController : CoreController
    {
        [HttpGet("GetUserData")]
        public async Task<IActionResult> GetUserData()
        {
            var result = await Mediator.Send(new GetUserDataQuery());
            return Ok(result);
        }

        [HttpPost("AssignRoleToUser")]
        [Authorize(Roles = UserRoles.Admin)]
        public async Task<IActionResult> AssignRoleToUserAsync([FromBody] AssignRoleToUserCommand command)
        {
            var result = await Mediator.Send(command);
            return Ok(result);
        }
    }
}
