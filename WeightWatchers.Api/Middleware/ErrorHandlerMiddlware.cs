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
        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
                HttpStatusCode code = HttpStatusCode.OK;
                string result = "";
                if (context.Response.StatusCode == StatusCodes.Status401Unauthorized)
                {
                    code = HttpStatusCode.Unauthorized; 
                    result = JsonConvert.SerializeObject(new { error = "you aren't allowed" });
                   await context.Response.WriteAsync(result);
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
            HttpStatusCode code=HttpStatusCode.BadRequest;
            string result = JsonConvert.SerializeObject(new { error = ex.Message });

            if (context.Response.StatusCode == StatusCodes.Status401Unauthorized)
            {
                 code = HttpStatusCode.Unauthorized;
                 result = JsonConvert.SerializeObject(new { error = "you aren't allowed" });
            }
            //if (ex is MyNotFoundException) code = HttpStatusCode.NotFound;
            //else if (ex is MyUnauthorizedException) code = HttpStatusCode.Unauthorized;
            //else if (ex is MyException) code = HttpStatusCode.BadRequest;            
            // context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)code;
            return context.Response.WriteAsync(result);
        }
    }
}
