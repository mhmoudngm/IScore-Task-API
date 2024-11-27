using Application.Components.Users.AssignUserRoles;
using Application.Components.Users.GetUserData;
using Application.Constants;
using Domain.Entities;
using Infrastructure.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class UserContext : IUserContext
    {
        private readonly IHttpContextAccessor httpContext;
        private readonly AppDbContext context;
        private readonly IUserStore<User> userStore;
        private readonly UserManager<User> userManager;
        private readonly RoleManager<IdentityRole> roleManager;

        public UserContext(IHttpContextAccessor httpContext, AppDbContext context, IUserStore<User> userStore, UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
        {
            this.httpContext = httpContext;
            this.context = context;
            this.userStore = userStore;
            this.userManager = userManager;
            this.roleManager = roleManager;
        }
        public async Task<CurrentUser?> GetCurrentUser()
        {
            var user = httpContext?.HttpContext?.User;
            if (user == null)
            {
                throw new Exception("Not Found Any Users");
            }
            if (!user!.Identity!.IsAuthenticated)
            {
                return null;
            }
            var userid = user.FindFirst(i => i.Type == ClaimTypes.NameIdentifier)?.Value;
            var useremail = user.FindFirst(i => i.Type == ClaimTypes.Email)?.Value;
            var roles = user.Claims.Where(i => i.Type == ClaimTypes.Role)?.Select(i => i.Value).ToList();
            var currentuser = new CurrentUser
            {
                UserId = userid,
                Email = useremail,
                Roles = roles
            };
            return currentuser;
        }

        public async Task<GetUserDataQueryResult> GetUserData(GetUserDataQuery query)
        {
            var user = httpContext?.HttpContext?.User;
            if (user == null || !user!.Identity!.IsAuthenticated)
            {
                return null;
            }
            var userid = user.FindFirst(i => i.Type == ClaimTypes.NameIdentifier)?.Value;
            var useremail = user.FindFirst(i => i.Type == ClaimTypes.Email)?.Value;
            var roles = user.Claims.Where(i => i.Type == ClaimTypes.Role)?.Select(i => i.Value).ToList();
            var currentuser = new GetUserDataQueryResult
            {
                UserId = userid,
                Email = useremail,
                Roles = roles
            };
            return currentuser;
        }
        public async Task<bool> AssignRoleToUserAsync(AssignRoleToUserCommand command)
        {
            var user = await userManager.FindByEmailAsync(command.Email) ?? throw new Exception("not found this user");
            var role = await roleManager.FindByNameAsync(command.RoleName) ?? throw new Exception("not fount this role");
            await userManager.AddToRoleAsync(user, role.Name);
            return true;
        }
    }
}
