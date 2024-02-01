namespace MinimalAPI_example;
public class InternoMiddleware
{
    private readonly RequestDelegate _next;

    public InternoMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext context)
    {
        await context.Response.WriteAsync("Adicionou interno\n");
    }
}

public static class InternoMiddlewareExtensions
{
    public static IApplicationBuilder UseInternoMiddleware(this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<InternoMiddleware>();
    }
}
