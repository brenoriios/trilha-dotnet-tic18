using System.Diagnostics;
using System.Net.Mime;
using System.Text.Json;

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
        context.Response.Headers.Add("data-hora", DateTimeOffset.UtcNow.ToLocalTime().ToString());
        context.Response.Headers.Add("ip-origem", context.Connection.RemoteIpAddress.ToString());
        await _next(context);
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
        var stopwatch = Stopwatch.StartNew();
        var inicio = DateTimeOffset.UtcNow.Ticks;

        await _next(context);

        stopwatch.Stop();

        var tDuracao = stopwatch.ElapsedTicks /  1000;
        await context.Response.WriteAsync($"{tDuracao} microsegundos\n");
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
            context.Response.StatusCode = 200;
            JsonMessage jsonMessage = new JsonMessage(){
                StatusCode = context.Response.StatusCode,
                ExceptionType = ex.GetType().ToString(),
                Message = ex.Message
            };
            await context.Response.WriteAsJsonAsync(JsonSerializer.Serialize(jsonMessage));
        }
    }
}

public class JsonMessage
{
    public int StatusCode { get; set;}
    public string? ExceptionType { get; set; }
    public string? Message { get; set; }
}
