using P08_Services;

var builder = WebApplication.CreateBuilder(args);

// register the CitiesService
builder.Services.AddScoped<CitiesService>();
builder.Services.AddControllersWithViews();

var app = builder.Build();
app.UseStaticFiles();
app.UseRouting();
app.MapControllers();

app.Run();