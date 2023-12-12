using Microsoft.AspNetCore.Builder;
using WebLab.Middleware;

namespace WebLab.Extensions
{
    public static class appExtensions
    {
        public static IApplicationBuilder UseFileLogging(this IApplicationBuilder app)
        => app.UseMiddleware<LogMiddleware>();
    }
}
