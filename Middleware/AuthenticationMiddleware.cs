using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace WeatherApplication.Middleware
{
    public class AuthenticationMiddleware
    {
        private readonly RequestDelegate _next;

  
        public AuthenticationMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            //Reading the AuthHeader which is signed with JWT
            string authHeader = context.Request.Headers["authentication"];

            if (authHeader != null)
            {
                
            }
            //Pass to the next middleware
            await _next(context);
        }
    }
}
