using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace BookStore.Middleware
{
    public class CustomExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        public CustomExceptionMiddleware(RequestDelegate next) {
            _next = next;
        }

        public async Task Invoke(HttpContext context) 
        {
            var watch = Stopwatch.StartNew();
            try
            {
                string message = "[Request] HTTP " + context.Request.Method + " - " + context.Request.Path;
                Console.WriteLine(message);
                await _next(context);
                watch.Stop();
                message = "[Response] HTTP" + context.Request.Method + " - " + context.Request.Path + " responded " + context.Response.StatusCode + "in" + watch.Elapsed.TotalMilliseconds + "ms";

            }
            catch(Exception ex) 
            {
                watch.Stop();
                await HandleException(context, ex, watch);
            }
        }

        private Task HandleException(HttpContext context, Exception ex, Stopwatch watch)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

            string message = "[Error] HTTP" + context.Request.Method + " - " + context.Response.StatusCode + "Errpr Message" + ex.Message + "in" + watch.Elapsed.TotalMilliseconds + "ms";
            Console.WriteLine(message);

            var result = JsonConvert.SerializeObject(new { error = ex.Message}, Formatting.None);
            return context.Response.WriteAsync(result);
        }
    }

    public static class CustomExceptionMiddlewareExtention
    {
        public static IApplicationBuilder UserCustomExceptionMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<CustomExceptionMiddleware>();
        }
    }
}
