namespace P01_Middleware.CustomMiddleware;

public class MyCustomMiddleware1
{
    private readonly RequestDelegate _next;

    public MyCustomMiddleware1(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext context)
    {
        // before logic
        if (context.Request.Query.ContainsKey("firstName") && context.Request.Query.ContainsKey("lastName"))
        {
            string fullName = context.Request.Query["firstName"] + " " + context.Request.Query["lastName"];
            await context.Response.WriteAsync($"full name: {fullName}\n");
        }

        await _next(context);
        // after logic
    }
}

public static class MyCustomMiddleware1Extensions
{
    public static IApplicationBuilder UseMyCustomMiddleware1(this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<MyCustomMiddleware1>();
    }
}