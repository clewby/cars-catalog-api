using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace SB.CarsCatalog.Api.Errors
{
    /// <summary>
    /// Global Exception Handling
    /// </summary>
    public class ExceptionMiddleware
    {
        /// <summary>
        /// Request Delegate
        /// </summary>
        private readonly RequestDelegate next;

        /// <summary>
        /// Exception Middleware ctor
        /// </summary>
        /// <param name="next">next</param>
        public ExceptionMiddleware(RequestDelegate next)
        {
            this.next = next;
        }
        /// <summary>
        /// Invoke
        /// </summary>
        /// <param name="context">context</param>
        /// <returns></returns>
        public async Task Invoke(HttpContext context)
        {
            try
            {
                await next(context);
            }
            catch (HttpStatusCodeException ex)
            {
                await HandleExceptionAsync(context, ex);
            }
            catch (Exception exceptionObj)
            {
                await HandleExceptionAsync(context, exceptionObj);
            }
        }
        /// <summary>
        /// Handle Exception Async
        /// </summary>
        /// <param name="context">context</param>
        /// <param name="exception">exception</param>
        /// <returns></returns>
        private Task HandleExceptionAsync(HttpContext context, HttpStatusCodeException exception)
        {
            string result = null;
            context.Response.ContentType = "application/json";
            if (exception is HttpStatusCodeException)
            {
                result = new ErrorDetails() { Message = exception.Message, StatusCode = (int)exception.StatusCode }.ToString();
                context.Response.StatusCode = (int)exception.StatusCode;
            }
            else
            {
                result = new ErrorDetails() { Message = "Runtime Error", StatusCode = (int)HttpStatusCode.BadRequest }.ToString();
                context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
            }
            return context.Response.WriteAsync(result);
        }
        /// <summary>
        /// Handle Exception Async
        /// </summary>
        /// <param name="context">context</param>
        /// <param name="exception">exception</param>
        /// <returns></returns>
        private Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            var result = new ErrorDetails() { Message = exception.Message, StatusCode = (int)HttpStatusCode.InternalServerError };
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            return context.Response.WriteAsync(JsonConvert.SerializeObject(result));
        }
    }
}
