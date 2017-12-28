using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace testingSSL.Middleware
{
    public class HstsMiddleware
    {
        private readonly RequestDelegate _next;
        public HstsMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public Task Invoke(HttpContext context)
        {
            if (!context.Request.IsHttps)
                return _next(context);

            if (IsLocalhost(context))
                return _next(context);

            context.Response.Headers.Add("Strict-Transport-Security", "max-age=31536000");

            return _next(context);
        }
        private bool IsLocalhost(HttpContext context)
        {
            return string.Equals(context.Request.Host.Host, "localhost", StringComparison.OrdinalIgnoreCase);
        }
    }
}