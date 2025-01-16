using Microsoft.AspNetCore.Diagnostics;
using System.Net.Mime;
using System.Net;
using System.Text.Json;

namespace BookHive.API.Extensions;

public static class ConfigureExceptionHandlerExtension
{
    public static void ConfigureExceptionHandler<T>(this WebApplication application, ILogger<T> logger)
    {
        application.UseExceptionHandler(builder =>
        {
            builder.Run(async context =>
            {
                context.Response.ContentType = MediaTypeNames.Application.Json;

                var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
                if (contextFeature != null)
                {
                    context.Response.StatusCode = contextFeature.Error is ArgumentException
                        ? (int)HttpStatusCode.BadRequest
                        : (int)HttpStatusCode.InternalServerError;

                    var traceId = context.TraceIdentifier;
                    logger.LogError($"TraceId: {traceId}, Error: {contextFeature.Error.Message}, StackTrace {contextFeature.Error.StackTrace}");

                    var errorResponse = new
                    {
                        TraceId = traceId,
                        StatusCode = context.Response.StatusCode,
                        Message = application.Environment.IsDevelopment()
                        ? contextFeature.Error.Message
                        : "An error occurred. Please contact support.",
                        Title = "Error occurred",
                        TimeStamp = DateTime.UtcNow.AddHours(4).ToString("o")
                    };

                    var options = new JsonSerializerOptions { WriteIndented = true };
                    await context.Response.WriteAsync(JsonSerializer.Serialize(errorResponse, options));
                }
            });
        });
    }
}
