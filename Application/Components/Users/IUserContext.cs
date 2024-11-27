using Application.Components.Users.AssignUserRoles;
using Application.Components.Users.GetUserData;
using Infrastructure.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public interface IUserContext
    {
        Task<CurrentUser?> GetCurrentUser();
        Task<GetUserDataQueryResult> GetUserData(GetUserDataQuery query);
        Task<bool> AssignRoleToUserAsync(AssignRoleToUserCommand command);
    }
}
