namespace MinimalAPI_example;
public class ChassiMiddleware
{
    private readonly RequestDelegate _next;
    public ChassiMiddleware(RequestDelegate next)
    {
        _next = next;
    }
    public async Task Invoke(HttpContext context)
    {
        await context.Response.WriteAsync("Adicionou chassi\n");
        await _next.Invoke(context);
    }
}

public static class ChassiMiddlewareExtensions
{
    public static IApplicationBuilder UseChassiMiddleware(this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<ChassiMiddleware>();
    }
}
