using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using P05_Views.Models;

namespace P05_Views.Controllers;

[Controller]
public class HomeController : Controller
{
    [Route("home")]
    [Route("/")]
    public IActionResult Index()
    {
        // return View("abc"); // view name is: abc.cshtml

        // default view name is: Index.cshtml
        // the view is searched and expected to be in the 'Views/Home/Index.cshtml'
        ViewData["appTitle"] = "Asp.Net Core App~";
        List<Person> people = new List<Person>()
        {
            new Person() { Name = "Tom", DateOfBirth = DateTime.Parse("2000-05-06"), PersonGender = Gender.Male },
            new Person() { Name = "Linda", DateOfBirth = DateTime.Parse("2005-01-09"), PersonGender = Gender.Female },
            new Person() { Name = "Susan", DateOfBirth = DateTime.Parse("2008-07-12"), PersonGender = Gender.Other },
        };
        ViewData["people"] = people;
        return View();
    }
}