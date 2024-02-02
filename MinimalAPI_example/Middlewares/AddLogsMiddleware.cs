using System.Net.Mime;

namespace MinimalAPI_example.Middlewares;
public class AddRequestData
{
    public readonly RequestDelegate _next;
    public AddRequestData(RequestDelegate next)
    {
        _next = next;
    }
    public async Task Invoke(HttpContext context)
    {
        var clientIpAddress = context.Connection.RemoteIpAddress;

        await _next(context);

        // context.Response.Headers.Add("request-start", $"DataHora: {DateTimeOffset.UtcNow.ToLocalTime()} - IP: {clientIpAddress}");
        await context.Response.WriteAsync($"DataHora: {DateTimeOffset.UtcNow.ToLocalTime()} - IP: {clientIpAddress}\n");
    }
}

public class AddRequestDurationMiddleware
{
    public readonly RequestDelegate _next;
    public AddRequestDurationMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext context)
    {
        var inicio = DateTimeOffset.UtcNow.Ticks;

        await _next(context);

        var fim = DateTimeOffset.UtcNow.Ticks;
        double duracao = (fim - inicio) / (TimeSpan.TicksPerMillisecond / 1000);
        await context.Response.WriteAsync($"{duracao} microsegundos\n");
        // context.Response.Headers.Add("request-duration", $"{duracao} microsegundos");
    }
}

public class AddRequestJsonException
{
    public readonly RequestDelegate _next;
    public AddRequestJsonException(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext context)
    {
        try
        {
            // throw new DivideByZeroException();
            await _next(context);
        }
        catch (Exception ex)
        {
            await context.Response.WriteAsJsonAsync(ex.Message);
        }
    }
}
