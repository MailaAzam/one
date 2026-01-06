namespace WebApplication1Demo.DAL
{
    public class ApiKeyMiddleware
    {
        private readonly RequestDelegate _next;
        private const string HeaderName = "X-API-KEY";
        private readonly string _apikey;

        public ApiKeyMiddleware(RequestDelegate next, IConfiguration configuration)
        {
            _next = next;
            _apikey = configuration["ApiKey"];
        }

        public async Task InvokeAsync(HttpContext context)
        {
            if (!context.Request.Headers.TryGetValue(HeaderName, out var extractedKey)
                || extractedKey != _apikey)
            {
                context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                await context.Response.WriteAsync("Invalid or missing API Key");
                return;
            }

            await _next(context);
        }
    }
}