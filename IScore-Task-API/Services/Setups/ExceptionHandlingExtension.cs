using Application.Common.Responses;
using Microsoft.AspNetCore.Diagnostics;
using System.Net;
using System.Text.Json;
using System.Text;
using ValidationException = FluentValidation.ValidationException;


namespace IScore_Task_API.Services.Setups
{
    public static class ExceptionHandlingExtension
    {
        public static void UseCustomeExceptionHandler(this IApplicationBuilder app)
        {
            app.UseExceptionHandler(x =>
            {
                x.Run(async context =>
                {
                    string errorText = "";
                    var errorFeature = context.Features.Get<IExceptionHandlerFeature>();
                    var exception = errorFeature.Error;
                    if (exception.GetType() == typeof(FluentValidation.ValidationException))
                    {
                        var validationException = (ValidationException)exception;
                        var response = new OutputResponseForValidationFilter
                        {
                            Message = "One or more validation failures have occurred.",
                            StatusCode = HttpStatusCode.BadRequest,
                            Success = false,
                            Model = null,
                            Errors = validationException.Errors.Select(err => new ErrorModel()
                            {
                                ErrorCode = err.ErrorCode,
                                Message = err.ErrorMessage,
                                Property = err.PropertyName
                            }).ToList()
                        };
                        errorText = JsonSerializer.Serialize(response, new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase });
                        context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                        context.Response.ContentType = "application/json";
                        await context.Response.WriteAsync(errorText, Encoding.UTF8);
                    }
                    else
                    {
                        string message = "Internal Server Error";
                        var response = new OutputResponse<string>
                        {
                            Message = message,
                            StatusCode = HttpStatusCode.InternalServerError,
                            Success = false,
                            Model = null,
                        };
                        errorText = JsonSerializer.Serialize(response, new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase });
                        context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                        context.Response.ContentType = "application/json";
                        await context.Response.WriteAsync(errorText, Encoding.UTF8);
                    }
                });
            });
        }
    }
}
