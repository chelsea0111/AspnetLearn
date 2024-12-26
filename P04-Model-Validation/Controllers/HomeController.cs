using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using P04_Model_Validation.Models;

namespace P04_Model_Validation.Controllers;

[Controller]
public class HomeController : Controller
{
    [Route("register")]
    public IActionResult Index(Person person)
    {
        if (!ModelState.IsValid)
        {
            List<string> errorList = ModelState.Values
                .SelectMany(value => value.Errors)
                .Select(err => err.ErrorMessage).ToList();

            return BadRequest(errorList);
        }

        return Content($"{person}");
    }
}