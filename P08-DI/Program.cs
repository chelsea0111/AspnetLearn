using P08_ServiceContracts;
using P08_Services;

var builder = WebApplication.CreateBuilder(args);

// register the Service into IoC Container base on interface
builder.Services.Add(
    new ServiceDescriptor(typeof(ICitiesService), typeof(CitiesService), ServiceLifetime.Singleton));
builder.Services.AddControllersWithViews();

var app = builder.Build();
app.UseStaticFiles();
app.UseRouting();
app.MapControllers();

app.Run();