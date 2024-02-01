using MinimalAPI_example;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.UseChassiMiddleware();
app.UseMotorMiddleware();
app.UsePortasMiddleware();
app.UsePinturaMiddleware();
app.UseInternoMiddleware();

app.Run();
