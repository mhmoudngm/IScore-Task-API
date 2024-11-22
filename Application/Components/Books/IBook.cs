using Application.Common.Responses;
using Application.Components.Books.Create;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Components.Books
{
    public interface IBook
    {
        Task <OutputResponse<CreateNewBookCommandResult>> CreateNewBook (CreateNewBookCommand command);
    }
}
