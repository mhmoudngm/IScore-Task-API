using Application.Components.Author.Create;
using Application.Components.Author.List;
using Application.Components.Books.Create;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IScore_Task_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class AuthorController : CoreController
    {

        [HttpPost("CreateNewAuthor")]
        public async Task<IActionResult> CreateNewAuthor([FromBody] CreateNewAuthorCommand command)
        {
            var result = await Mediator.Send(command);
            return Ok(result);
        }
        [HttpGet("GetAllAuthors")]
        public async Task<IActionResult> GetAllAuthors()
        {
            var result = await Mediator.Send(new GetAllAuthorsQuery() { });
            return Ok(result);
        }
    }
}
