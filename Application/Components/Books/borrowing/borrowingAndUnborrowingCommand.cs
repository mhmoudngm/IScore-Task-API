using Application.Common.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Components.Books.borrowing
{
    public class borrowingAndUnborrowingCommand:IRequest<OutputResponse<bool>>
    {
        public Guid Id { get; set; }
    }
}
