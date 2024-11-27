using Application.Common.Responses;
using Application.Components.Books.borrowing;
using Application.Components.Books.Create;
using Application.Components.Books.Delete;
using Application.Components.Books.Edit;
using Application.Components.Books.List;
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
        Task<OutputResponse<GetAllBooksQueryResult>> GetAllBooks(GetAllBooksQuery query);
        Task<OutputResponse<EditBookCommandResult>> EditBookInfo(EditBookCommand command);
        Task<OutputResponse<DeleteBookCommandResult>> DeleteBook(DeleteBookCommand command);
        Task<OutputResponse<bool>> borrowingAndUnborrowing(borrowingAndUnborrowingCommand command);
    }
}
