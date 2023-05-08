namespace CustomMiddleware.CustomMiddleware;

// You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
public class LoginCustomMiddleware
{
    private readonly RequestDelegate _next;
    private string username = "user";
    private string password = "pass";

    public LoginCustomMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext httpContext)
    {

        if (httpContext.Request.Query.ContainsKey("username") && httpContext.Request.Query.ContainsKey("password"))
        {
            string loginUser = httpContext.Request.Query["username"];
            string loginPass = httpContext.Request.Query["password"];

            if (username == loginUser && password == loginPass)
            {
                await httpContext.Response.WriteAsync("Login sucessful !!");
            }
            else
            {
                await httpContext.Response.WriteAsync("Login failed !!");
            }
        }
    }
}

// Extension method used to add the middleware to the HTTP request pipeline.
public static class LoginCustomMiddlewareExtensions
{
    public static IApplicationBuilder UseLoginCustomMiddleware(this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<LoginCustomMiddleware>();
    }
}
