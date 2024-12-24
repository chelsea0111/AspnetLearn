var builder = WebApplication.CreateBuilder(args);
// 1. add all the controllers classes as services in IServiceCollection.
// So that, they cna be accessed when a specific endpoint needs it.
builder.Services.AddControllers();

var app = builder.Build();

app.UseStaticFiles();
app.UseRouting();

// app.UseEndpoints(endpoints =>
// {
//     endpoints.MapControllers();
// });


// 2. adds all actions methods as endpoints.
// So that, no need of using UseEndPoints() method for adding action methods as endpoint
app.MapControllers();
app.Run();