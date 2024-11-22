using Microsoft.OpenApi.Models;

namespace IScore_Task_API.Services.Setups
{
    public static class SwaggerServiceSetup
    {
        public static void SwaggerSetup(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddSwaggerGen(c =>
            {
                c.AddSecurityDefinition("bearerAuth", new OpenApiSecurityScheme
                {
                    Type = SecuritySchemeType.Http,
                    Scheme = "Bearer"
                });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                  {
                       new OpenApiSecurityScheme
                       {
                          Reference =new OpenApiReference{Type=ReferenceType.SecurityScheme,Id="bearerAuth"}
                       },
                       []
                  }
                });
            });
        }
    }
}
