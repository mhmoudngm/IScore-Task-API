using Application.Components.Books.borrowing;
using Application.Components.Books.Create;
using Application.Components.Books.Delete;
using Application.Components.Books.Edit;
using Application.Components.Books.List;
using Application.Constants;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace IScore_Task_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class BookController : CoreController
    {

        [HttpPost("CreateNewBook")]
        public async Task<IActionResult> CreateNewBook([FromBody] CreateNewBookCommand command)
        {
            var result = await Mediator.Send(command);
            return Ok(result);
        }

        [HttpGet("GetAllBooks")]
        public async Task<IActionResult> GetAllBooks([FromQuery] GetAllBooksQuery query)
        {
            var result = await Mediator.Send(query);
            return Ok(result);
        }

        [HttpPut("Edit")]
        public async Task<IActionResult> EditBookInfo([FromBody] EditBookCommand command)
        {
            var result = await Mediator.Send(command);
            return Ok(result);
        }

        [HttpDelete("Delete")]
        [Authorize(Roles = UserRoles.Admin)]
        public async Task<IActionResult> DeleteBook([FromQuery] DeleteBookCommand command)
        {
            var result = await Mediator.Send(command);
            return Ok(result);
        }

        [HttpPost("borrowingAndUnborrowing")]
        public async Task<IActionResult> borrowingAndUnborrowing([FromQuery] Guid Id)
        {
            var result = await Mediator.Send(new borrowingAndUnborrowingCommand() { Id = Id });
            return Ok(result);
        }
    }
}
