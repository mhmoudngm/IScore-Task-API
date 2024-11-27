using Application.Components.Author;
using Application.Components.Books;
using Application.Components.Users;
using FluentValidation;
using Infrastructure.Components;
using Infrastructure.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;


namespace Infrastructure.Configuration
{
    public static class DependencyInjection
    {
        public static IServiceCollection RegisterInfrastructureLayer(this IServiceCollection services, IConfiguration config)
        {
            #region Contexts
            services.AddDbContext<AppDbContext>(opt => opt.UseSqlServer(config.GetConnectionString("Iscore")));
            #endregion
            #region Repos
            services.AddScoped<IBook, BookRepo>();
            services.AddScoped<IAuthor, AuthorRepo>();
            services.AddScoped<IUserContext, UserContext>();
            services.AddScoped<IUserRolesSeeds, UserRolesSeeds>();
            #endregion
            services.Setuppasswordsettings();
            #region Packages
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
            #endregion
            return services;
        }
        private static void Setuppasswordsettings(this IServiceCollection services)
        {
            services.Configure<IdentityOptions>(options =>
            {
                // Password settings
                options.Password.RequireDigit = true;
                options.Password.RequiredLength = 8;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireLowercase = false;
                options.Password.RequiredUniqueChars = 2;
            });
        }
    }
}
