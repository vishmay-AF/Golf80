using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Golf80.Infrastrucure.Core.MiddleWare
{
    [System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
    public class ErrorHandlingMiddleware
    {
        private readonly RequestDelegate next;
        public ErrorHandlingMiddleware(RequestDelegate next)
        {
            this.next = next;
        }

        public async Task Invoke(HttpContext context, ILogger<ErrorHandlingMiddleware> Logger, IHostEnvironment env)
        {
            try
            {
                await next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex, Logger, env);
                if (env.IsDevelopment())
                {
                    throw;
                }
            }
        }

        private static async Task HandleExceptionAsync(HttpContext context, Exception ex, ILogger<ErrorHandlingMiddleware> Logger, IHostEnvironment env)
        {
            Logger.LogError("{ \"Exception\" : \" " + ex + " \" }");
            if (!env.IsDevelopment())
            {
                var result = JsonConvert.SerializeObject(new
                {
                    ResponseCode = 500,
                    ResponseMessage = "Some error occoured. Please try again"
                });
                context.Response.ContentType = "application/json";
                context.Response.StatusCode = 500;
                await context.Response.WriteAsync(result);
            }
        }
    }
}
