using Microsoft.AspNetCore.Mvc;
using P03_Controllers.Models;

namespace P03_Controllers.Controllers;

public class HomeController : Controller
{
    // 3. attribute routing
    [Route("home")]
    [Route("/")]
    public ContentResult Index()
    {
        // return new ContentResult()
        // {
        //     Content = "Hello from home!~~~", ContentType = "text/plain"
        // };

        // to use this predefined method, the XxxController must inherit from the Controller parent class
        return Content("<h1>Hello from home!~~~!!!</h1> <h2>I'm h2</h2>", "text/html");
    }

    [Route("person")]
    public JsonResult Person()
    {
        Person person = new Person()
        {
            Id = Guid.NewGuid(), FirstName = "James", LastName = "Smith", Age = 25
        };
        // return new JsonResult(person);

        // to use this predefined method, the XxxController must inherit from the Controller parent class
        return Json(person);
    }

    [Route("contact-us/{mobile:regex(^\\d{{10}}$)}")]
    public string Contact()
    {
        return "Hello from contact!";
    }

    [Route("file-download1")]
    public VirtualFileResult FileDownload()
    {
        return new VirtualFileResult("/carr.png", "image/png");
    }
    
    [Route("file-download2")]
    public PhysicalFileResult FileDownload2()
    {
        return new PhysicalFileResult("/Users/xuxinyi/code/dotnet/aspnet_basic/learn/AspnetLearn/P03-Controllers/wwwroot/carr.png", "image/png");
    }

    [Route("file-download3")]
    public IActionResult FileDownload3()
    {
        byte[] bytes = System.IO.File.ReadAllBytes("/Users/xuxinyi/code/dotnet/aspnet_basic/learn/AspnetLearn/P03-Controllers/wwwroot/carr.png");
        // return new FileContentResult(bytes, "image/png");
        return File(bytes, "image/png");
    }
}