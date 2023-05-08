using CustomMiddleware.CustomMiddleware;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.UseLoginCustomMiddleware();

app.Run();
