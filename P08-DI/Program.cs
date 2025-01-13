using Autofac;
using Autofac.Extensions.DependencyInjection;
using P08_ServiceContracts;
using P08_Services;

var builder = WebApplication.CreateBuilder(args);

// use a custom or third-party service provider factory instead of built-in IoC container
builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
// add services into autoFac 
builder.Host.ConfigureContainer<ContainerBuilder>(containerBuilder =>
{
    containerBuilder.RegisterType<CitiesService>()
        .As<ICitiesService>()
        // .InstancePerDependency(); // as transient
        // .SingleInstance(); // as singleton
        .InstancePerLifetimeScope(); // as scoped
});

builder.Services.AddControllersWithViews();


var app = builder.Build();
app.UseStaticFiles();
app.UseRouting();
app.MapControllers();

app.Run();