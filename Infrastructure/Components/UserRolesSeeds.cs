using Application.Components.Users;
using Application.Constants;
using Microsoft.AspNetCore.Identity;

namespace Infrastructure.Components
{
    public class UserRolesSeeds: IUserRolesSeeds
    {
        private readonly AppDbContext context;

        public UserRolesSeeds(AppDbContext context)
        {
            this.context = context;
        }
        public async Task<bool> SetUserRolesSeeds()
        {
            if (!context.Roles.Any())
            {
                var roles = GetUserRoles();
                context.Roles.AddRange(roles);
                await context.SaveChangesAsync();
            }
            return true;
        }
        private List<IdentityRole> GetUserRoles()
        {
            var list = new List<IdentityRole>()
            {
                new IdentityRole(UserRoles.Admin)
                {
                    Name =UserRoles.Admin,
                    NormalizedName=UserRoles.Admin.ToUpper()
                },
                new IdentityRole(UserRoles.User)
                {
                      Name =UserRoles.User,
                    NormalizedName= UserRoles.User.ToUpper()
                }
            };
            return list;
        }
    }
}
