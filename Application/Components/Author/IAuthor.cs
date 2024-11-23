using Application.Common.Responses;
using Application.Components.Author.Create;
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
    }
}
