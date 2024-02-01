namespace MinimalAPI_example;
public class PinturaMiddleware
{
    private readonly RequestDelegate _next;

    public PinturaMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext context)
    {
        await context.Response.WriteAsync("Adicionou pintura\n");
        await _next.Invoke(context);
    }
}

public static class PinturaMiddlewareExtensions
{
    public static IApplicationBuilder UsePinturaMiddleware(this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<PinturaMiddleware>();
    }
}
