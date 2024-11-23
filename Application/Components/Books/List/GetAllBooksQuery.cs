using Application.Common.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Components.Books.List
{
    public class GetAllBooksQuery:IRequest<OutputResponse<GetAllBooksQueryResult>>
    {
        public string? Term { get; set; }
        public int PageSize { get; set; }
        public int PageNumber { get; set; }
    }
}
