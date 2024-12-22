var builder = WebApplication.CreateBuilder(args);
// 1. add all the controllers classes as services
builder.Services.AddControllers();

var app = builder.Build();
// app.UseRouting();
// app.UseEndpoints(endpoints =>
// {
//     endpoints.MapControllers();
// });
// 2. enables the routing for each action method in controllers
app.MapControllers();
app.Run();