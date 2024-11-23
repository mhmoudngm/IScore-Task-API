using Application.Components.Books.Create;
using Application.Components.Books.List;
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
    }
}
