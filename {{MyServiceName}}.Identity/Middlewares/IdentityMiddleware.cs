using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace __MyServiceName__.Identity.Middlewares
{
    public class IdentityMiddleware
    {
        private readonly RequestDelegate _next;

        public IdentityMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            // Example: attach user info from JWT or cookie
            // context.Items["User"] = ...

            await _next(context);
        }
    }
    //public static class IdentityMiddlewareExtensions
    //{
    //    public static IApplicationBuilder UseIdentityModule(this IApplicationBuilder app)
    //    {
    //        return app.UseMiddleware<IdentityMiddleware>();
    //    }
    //}

}
