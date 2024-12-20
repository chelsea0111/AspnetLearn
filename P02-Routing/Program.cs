using P02_Routing.CustomConstraints;

var builder = WebApplication.CreateBuilder(args);

// register my custom constraint in the services
builder.Services.AddRouting(options =>
{
    options.ConstraintMap.Add("months", typeof(MonthCustomConstraint));
});

var app = builder.Build();

app.UseStaticFiles();

// enable routing
app.UseRouting();

app.UseEndpoints(async endpoints =>
{
    endpoints.Map("files/{filename}.{extension}", async context =>
    {
        string? fileName = Convert.ToString(context.Request.RouteValues["filename"]);
        string? extension = Convert.ToString(context.Request.RouteValues["extension"]);

        await context.Response.WriteAsync($"In files - {fileName}.{extension}");
    });

    endpoints.Map("employee/profile/{employeeName=Jack}", async context =>
    {
        string? employeeName = Convert.ToString(context.Request.RouteValues["employeeName"]);
        await context.Response.WriteAsync($"In employee - {employeeName}");
    });

    endpoints.Map("products/details/{id:int?}", async context =>
    {
        int id = Convert.ToInt32(context.Request.RouteValues["id"]);
        await context.Response.WriteAsync($"In products - {id}");
    });

    // route constraints - datetime
    endpoints.Map("employee/enter/{date:datetime}", async context =>
    {
        var dateTime = Convert.ToDateTime(context.Request.RouteValues["date"]);
        await context.Response.WriteAsync($"dateTime - {dateTime.ToShortDateString()}");
    });

    // route constraints - guid
    endpoints.Map("cities/{cityid:guid}", async context =>
    {
        Guid guid = Guid.Parse(context.Request.RouteValues["cityid"].ToString());
        await context.Response.WriteAsync($"Guid is: {guid}");
    });

    // route constraints - minlength/maxlength
    endpoints.Map("phone/{phonenumber:}", async context =>
    {
        Guid guid = Guid.Parse(context.Request.RouteValues["cityid"].ToString());
        await context.Response.WriteAsync($"Guid is: {guid}");
    });

    // route constraints - regex
    // endpoints.Map("sales-report/{year:int:min(1990)}/{month:regex(^(apr)|(jul)|(oct)|(jan)$)}",
    //     async context =>
    //     {
    //         int year = Convert.ToInt32(context.Request.RouteValues["year"]);
    //         string? month = Convert.ToString(context.Request.RouteValues["month"]);
    //         await context.Response.WriteAsync($"sales report - {year} - {month}");
    //     });
    
    // route constraints - custom constraint
    endpoints.Map("sales-report/{year:int:min(1990)}/{month:months}",
        async context =>
        {
            int year = Convert.ToInt32(context.Request.RouteValues["year"]);
            string? month = Convert.ToString(context.Request.RouteValues["month"]);
            await context.Response.WriteAsync($"sales report - {year} - {month}");
        });
    
    
    // access to the wwwroot
    endpoints.Map("/", async context =>
    {
        await context.Response.WriteAsync("Hello");
    });
});

app.Run(async context => { await context.Response.WriteAsync($"Request received at {context.Request.Path}"); });

app.Run();