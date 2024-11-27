using Infrastructure.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Components.Users.GetUserData
{
    public class GetUserDataQueryHandler : IRequestHandler<GetUserDataQuery, GetUserDataQueryResult>
    {
        private readonly IUserContext userContext;

        public GetUserDataQueryHandler(IUserContext userContext)
        {
            this.userContext = userContext;
        }
        public async Task<GetUserDataQueryResult> Handle(GetUserDataQuery request, CancellationToken cancellationToken)
        {
            return await userContext.GetUserData(request);
        }
    }
}
