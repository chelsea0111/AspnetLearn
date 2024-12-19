using Microsoft.AspNetCore.Mvc.ApplicationParts;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

// only execute when the condition is true
app.UseWhen(
    context => context.Request.Query.ContainsKey("username"),
    app =>
    {
        app.Use(async (context, next) =>
        {
            await context.Response.WriteAsync($"Hello {context.Request.Query["username"]}!\n");
            await next();
        });
    }
);

// Any requests will come here.
app.Run(async context =>
{
    await context.Response.WriteAsync("hello from main chain!");
});

app.Run();