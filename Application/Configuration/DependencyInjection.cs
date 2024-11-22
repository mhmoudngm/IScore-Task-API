using FluentValidation;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Application.Configuration
{
    public static class DependencyInjection
    {
        public static IServiceCollection RegisterApplicationLayer(this IServiceCollection services, IConfiguration config)
        {
          
            #region Packages
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
            #endregion
            return services;
        }
    }
}
