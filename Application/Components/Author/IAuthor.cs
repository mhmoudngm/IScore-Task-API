using Application.Common.Responses;
using Application.Components.Author.Create;
using Application.Components.Author.List;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Components.Author
{
    public interface IAuthor
    {
        Task<OutputResponse<bool>> CreateNewAuthor(CreateNewAuthorCommand command);
        Task<OutputResponse<GetAllAuthorsQueryResult>> GetAllAuthors(GetAllAuthorsQuery query);
    }
}
