using Infrastructure.Services.Tenant;

namespace Base.Middleware
{
    public class TenantMiddleware
    {
        private readonly RequestDelegate _next;

        public TenantMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext, ITenantService tenantService)
        {
            var host = httpContext.Request.Host.Host;
            var tenant = tenantService.GetTenant(host);
            if (tenant != null)
            {
                httpContext.Items["Tenant"] = tenant;
            }

            await _next(httpContext);
        }
    }

}
