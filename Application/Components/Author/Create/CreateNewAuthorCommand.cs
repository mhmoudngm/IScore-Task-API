using Application.Common.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Components.Author.Create
{
    public class CreateNewAuthorCommand:IRequest<OutputResponse<bool>>
    {
        public string Name { get; set; }

    }
}
