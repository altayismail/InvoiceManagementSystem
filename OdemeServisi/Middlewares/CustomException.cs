using Newtonsoft.Json;
using OdemeSistemi.Services;
using System.Diagnostics;
using System.Net;

namespace OdemeSistemi.Middlewares
{
    public class CustomException
    {
        private readonly RequestDelegate _requestDelegate;

        private readonly ILoggerService _loggerService;

        public CustomException(RequestDelegate requestDelegate, ILoggerService loggerService)
        {
            _requestDelegate = requestDelegate;
            _loggerService = loggerService;
        }

        private Task HandleException(HttpContext context, Exception Ex, Stopwatch watch)
        {
            string message = "[Error] - HTTP " + context.Request.Method + " - " +
                                context.Response.StatusCode + " Error Message: " + Ex.Message + " in " +
                                watch.Elapsed.Milliseconds + " ms.";
            _loggerService.Write(message);

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)(HttpStatusCode.InternalServerError);

            var result = JsonConvert.SerializeObject(new { error = Ex.Message }, Formatting.None);
            return context.Response.WriteAsync(result);
        }

        public async Task Invoke(HttpContext context)
        {
            var watch = Stopwatch.StartNew();

            try
            {
                string message = "[Request] - HTTP " + context.Request.Method + " - " +
                                 context.Request.Path;
                _loggerService.Write(message);
                await _requestDelegate(context);
                watch.Stop();
                message = "[Response] - HTTP " + context.Request.Method + " - " + context.Request.Path +
                    " responded " + context.Response.StatusCode + " in" + watch.Elapsed.Milliseconds + " ms.";
                _loggerService.Write(message);
            }
            catch (Exception ex)
            {
                watch.Stop();
                await HandleException(context, ex, watch);
            }
        }
    }

    public static class CustomExceptionMiddleware
    {
        public static IApplicationBuilder UseCustomExceptionMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<CustomException>();
        }
    }
}
