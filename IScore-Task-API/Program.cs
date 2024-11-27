using Domain.Entities;
using Infrastructure;
using Microsoft.AspNetCore.Identity;
using Application.Configuration;
using Infrastructure.Configuration;
using IScore_Task_API.Services.Setups;
using Microsoft.Extensions.Options;
using Application.Components.Users;

var builder = WebApplication.CreateBuilder(args);
IConfiguration config = builder.Configuration;
// Add services to the container.
builder.Services.AddAuthentication();
builder.Services.AddControllers().AddNewtonsoftJson(options =>
{
    options.SerializerSettings.Formatting = Newtonsoft.Json.Formatting.Indented;
    // Configure other settings as needed
});

builder.Services.RegisterInfrastructureLayer(config);
builder.Services.AddIdentityApiEndpoints<User>().AddRoles<IdentityRole>().AddEntityFrameworkStores<AppDbContext>();
builder.Services.AddHttpContextAccessor();
builder.Services.RegisterApplicationLayer(config);
builder.Services.SwaggerSetup(config);
builder.Services.AddEndpointsApiExplorer();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapGroup("api/identity").MapIdentityApi<User>();
app.UseAuthorization();
//app.UseCustomeExceptionHandler();
app.UseCors(options =>
{
    options.WithOrigins("http://localhost:8080", "http://localhost:8081") 
          .AllowAnyHeader()                    
          .AllowAnyMethod();                   
});
var scope = app.Services.CreateScope();
var seeder = scope.ServiceProvider.GetRequiredService<IUserRolesSeeds>();
await seeder.SetUserRolesSeeds();
app.MapControllers();

app.Run();
