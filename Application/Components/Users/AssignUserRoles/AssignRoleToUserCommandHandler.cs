using Infrastructure.Services;
using MediatR;

namespace Application.Components.Users.AssignUserRoles
{
    public class AssignRoleToUserCommandHandler : IRequestHandler<AssignRoleToUserCommand, bool>
    {
        private readonly IUserContext userContext;

        public AssignRoleToUserCommandHandler(IUserContext userContext)
        {
            this.userContext = userContext;
        }
        public async Task<bool> Handle(AssignRoleToUserCommand request, CancellationToken cancellationToken)
        {
            return await userContext.AssignRoleToUserAsync(request);
        }
    }
}
