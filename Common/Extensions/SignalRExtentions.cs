using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Primitives;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Common.Extensions
{
    public static class SignalRExtentions
    {
        public const string HUBS = "/hub";
        public static void UseJwtHubs(this JwtBearerOptions options)
        {
            options.Events = new JwtBearerEvents
            {
                OnMessageReceived = context =>
                {
                    StringValues accessToken = context.Request.Query["access_token"] == StringValues.Empty
                        ? context.Request.Headers["Authorization"]
                        : context.Request.Query["access_token"];
                    
                    var path = context.HttpContext.Request.Path;
                    if(!string.IsNullOrEmpty(accessToken) && path.StartsWithSegments(HUBS))
                    {
                        var tokenHandler = new JwtSecurityTokenHandler();

                        var token = tokenHandler.ReadJwtToken(accessToken);
                        var jwtToken = token as JwtSecurityToken;
                        var username = jwtToken.Claims.First(x=> x.Type == ClaimTypes.Name).Value;

                        context.HttpContext.Items["username"] = username;
                        context.Token = accessToken;
                    }
                    return Task.CompletedTask;
                }
            };
        }

        public static string GetUser(this HubCallerContext context)
        {
            return context!.GetHttpContext()!.GetUser();
        }
    }
}
