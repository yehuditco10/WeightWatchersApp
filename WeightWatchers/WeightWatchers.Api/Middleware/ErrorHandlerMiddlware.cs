using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace WeightWatchers.Api.Middleware
{
    public class ErrorHandlerMiddlware
    {
        private readonly RequestDelegate _next;

        public ErrorHandlerMiddlware(RequestDelegate next)
        {
            _next = next;
        }
        public async Task Invoke(HttpContext context /* other dependencies */)
        {
            try
            {
              
                //  await context.Response.WriteAsync("in invoke - middleware");
                await _next(context);//if it asynce ->catch
                if (context.Response.StatusCode == StatusCodes.Status401Unauthorized)
                {
                    var code = HttpStatusCode.Unauthorized; 
                    var result = JsonConvert.SerializeObject(new { error = "you aren't allowed" });
                    //context.Response.ContentType = "application/json";
                    //context.Response.StatusCode = 401;
                    context.Response.WriteAsync(result);
                }
                 

            }
            catch (Exception ex)
            {
                // await context.Response.WriteAsync("in catch - middleware");
                await HandleExceptionAsync(context, ex);
            }
        }
        private static Task HandleExceptionAsync(HttpContext context, Exception ex)
        {
            var code = StatusCodes.Status400BadRequest;
            //if (ex is MyNotFoundException) code = HttpStatusCode.NotFound;
            //else if (ex is MyUnauthorizedException) code = HttpStatusCode.Unauthorized;
            //else if (ex is MyException) code = HttpStatusCode.BadRequest;

            var result = JsonConvert.SerializeObject(new { error = "you arent allowed" });
           // context.Response.ContentType = "application/json";
            context.Response.StatusCode = 401;
            return context.Response.WriteAsync(result);
        }
    }
}
