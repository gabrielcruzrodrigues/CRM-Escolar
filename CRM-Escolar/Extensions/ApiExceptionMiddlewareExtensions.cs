using Microsoft.AspNetCore.Diagnostics;
using System.Net;

namespace CRM_Escolar.Extensions
{
    public static class ApiExceptionMiddlewareExtensions 
    {
        //add Configure Exception Handler in IApplicationBuilder interface
        public static void ConfigureExceptionHandler(this IApplicationBuilder app)
        {
            app.UseExceptionHandler(appError =>
            {
                appError.Run(async context =>
                {
                    var exceptionHandlerPathFeature = context.Features.Get<IExceptionHandlerPathFeature>();

                    if (exceptionHandlerPathFeature?.Error is HttpResponseException httpResponseException)
                    {
                        context.Response.StatusCode = httpResponseException.StatusCode;
                        context.Response.ContentType = "application/json";
                        await context.Response.WriteAsJsonAsync(httpResponseException.Value);
                    }
                    else
                    {
                        context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                        await context.Response.WriteAsJsonAsync(new { message = "Ocorreu um erro inesperado." });
                    }
                });
            });
        }
    }

}

