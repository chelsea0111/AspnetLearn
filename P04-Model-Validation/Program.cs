using P04_Model_Validation.CustomValidators;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers(options =>
{
    // register
    options.ModelBinderProviders.Insert(0, new PersonBindProvider());
});
var app = builder.Build();

app.UseStaticFiles();
app.UseRouting();
app.MapControllers();

app.Run();