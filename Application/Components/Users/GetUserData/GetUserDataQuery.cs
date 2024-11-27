using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Components.Users.GetUserData
{
    public class GetUserDataQuery:IRequest<GetUserDataQueryResult>
    {
    }
}
