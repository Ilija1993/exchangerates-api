using ExchangeRates.Core.Exceptions;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Net;
using System.Threading.Tasks;

namespace ExchangeRates.API.Middlewares
{
    public class HttpExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        public HttpExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        /// <summary>
        /// Handles exception.
        /// </summary>
        /// <param name="context"></param>
        /// <param name="exception"></param>
        private async Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            HttpStatusCode statusCode;
            string exceptionMessage;

            if (exception is HttpException)
            {
                var httpException = exception as HttpException;
                statusCode = httpException.StatusCode;
                exceptionMessage = httpException.Message;
            }
            else
            {
                statusCode = HttpStatusCode.InternalServerError;
                exceptionMessage = exception.Message;
            }

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)statusCode;

            await context.Response.WriteAsync(JsonConvert.SerializeObject(new
            {
                Data = exceptionMessage
            }));

        }
    }
}
