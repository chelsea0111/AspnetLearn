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
            new Person() { Name = "Susan", DateOfBirth = null, PersonGender = Gender.Other },
        };
        // ViewBag.people = people;
        return View(people);
    }

    [Route("person-details/{name}")]
    public IActionResult Details(string? name)
    {
        if (name == null)
        {
            return Content("Person name can't be null");
        }

        List<Person> people = new List<Person>()
        {
            new Person() { Name = "Tom", DateOfBirth = DateTime.Parse("2000-05-06"), PersonGender = Gender.Male },
            new Person() { Name = "Linda", DateOfBirth = DateTime.Parse("2005-01-09"), PersonGender = Gender.Female },
            new Person() { Name = "Susan", DateOfBirth = null, PersonGender = Gender.Other },
        };
        Person? matchingPerson = people.FirstOrDefault(temp => temp.Name == name);
        return View(matchingPerson); // Views/Home/Details.cshtml
    }

    [Route("person-with-product")]
    public IActionResult PersonWithProduct()
    {
        Person person = new Person()
            { Name = "Sara", PersonGender = Gender.Female, DateOfBirth = DateTime.Parse("1998-05-24") };
        Product product = new Product() { ProductId = 1, ProductName = "Air Conditioner" };
        PersonAndProductWrapperModel personAndProductWrapperModel = new PersonAndProductWrapperModel()
            { PersonData = person, ProductData = product };
        return View(personAndProductWrapperModel);
    }
}