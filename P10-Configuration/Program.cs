using P10_Configuration;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();
// supply an object of WeatherApiOptions  (with 'WeatherApiOptions' section) as a service
builder.Services.Configure<WeatherApiOptions>(builder.Configuration.GetSection("WeatherApi"));

var app = builder.Build();

app.UseStaticFiles();
app.UseRouting();

app.MapControllers();
app.Run();