var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.Use(async (context, next) =>
{
    Endpoint? endpoint = context.GetEndpoint(); // it will be null if it's before app.UseRouting();
    Console.WriteLine(endpoint == null);
    await next();
});

// enable routing
app.UseRouting();

app.Use(async (context, next) =>
{
    Endpoint? endpoint = context.GetEndpoint(); 
    Console.WriteLine(endpoint == null);
    await next();
});

// creating end points
app.UseEndpoints((IEndpointRouteBuilder endpoints) =>
{
    endpoints.Map("map1",
        async (context) => await context.Response.WriteAsync("In Map 1"));
    endpoints.MapGet("map2",
        async (context) => await context.Response.WriteAsync("In Map 2"));
});

app.Run(async context => { await context.Response.WriteAsync($"Request received at {context.Request.Path}"); });

app.Run();