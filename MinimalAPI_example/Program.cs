using MinimalAPI_example.Middlewares;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.UseMiddleware<AddRequestJsonException>();
app.UseMiddleware<AddRequestDurationMiddleware>();
app.UseMiddleware<AddRequestData>();
app.Run(
    async (context) => {}
);

app.Run();
