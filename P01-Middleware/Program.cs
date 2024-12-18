using System.Text;
using P01_Middleware.CustomMiddleware;

var builder = WebApplication.CreateBuilder(args);
// add my own middleware class as a service
builder.Services.AddTransient<MyCustomMiddleware>();
var app = builder.Build(); 

// app.MapGet("/", () => "Hello World!");
// middleware 1
app.Use(async (HttpContext context, RequestDelegate next) =>
{
    await context.Response.WriteAsync("Hello start \n");
    await next.Invoke(context);
    await context.Response.WriteAsync("Hello end \n");
});

// middleware 2
// app.UseMiddleware<MyCustomMiddleware>();
app.UseMyCustomMiddleware();

// middleware 3
app.UseMyCustomMiddleware1();

// middleware 4
app.Run(async (HttpContext context) => { await context.Response.WriteAsync("ChelseaX\n"); });

app.Run();